using System.Collections;
using System.Collections.Generic;

namespace TuringMachine.Domain
{
    public class Tape : IEnumerable<char>
    {
        public const char Placeholder = ' ';
        private readonly LinkedList<char> tape = new LinkedList<char>();
        private LinkedListNode<char> current;

        internal Tape(Tape tape)
            : this(tape.GetLeft(), tape.Current, tape.GetRight())
        {
        }

        public Tape(IEnumerable<char> left = null, char middle = Placeholder, IEnumerable<char> right = null)
        {
            if (left != null)
                AddRange(left);

            MoveRight();
            Current = middle;
            var buf = current;

            if (right != null)
                AddRange(right);

            current = buf;
        }

        public char Current
        {
            get => current.Value;
            set => current.Value = value;
        }

        public void MoveLeft()
        {
            current = current?.Previous;
            if (current != null)
                return;

            current = CreateNewNode();
            tape.AddFirst(current);
        }

        public void MoveRight()
        {
            current = current?.Next;
            if (current != null)
                return;

            current = CreateNewNode();
            tape.AddLast(current);
        }

        public IEnumerator<char> GetEnumerator()
        {
            return tape.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public IEnumerable<char> GetLeft()
        {
            return GetRangeBeforeEnd(tape.First, current);
        }

        public IEnumerable<char> GetRight()
        {
            return GetRangeBeforeEnd(current.Next, null);
        }

        private static LinkedListNode<char> CreateNewNode()
        {
            return new LinkedListNode<char>(Placeholder);
        }

        private void AddRange(IEnumerable<char> data)
        {
            foreach (var word in data)
            {
                MoveRight();
                Current = word;
            }
        }

        private static IEnumerable<char> GetRangeBeforeEnd(LinkedListNode<char> start, LinkedListNode<char> end)
        {
            while (start != null && start != end)
            {
                yield return start.Value;
                start = start.Next;
            }
        }
    }
}