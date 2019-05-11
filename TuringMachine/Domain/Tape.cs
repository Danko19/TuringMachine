using System.Collections;
using System.Collections.Generic;
using System.Linq;

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

        public Dictionary<int, char> ToDictionary()
        {
            var result = new Dictionary<int, char>();

            var left = GetLeft().ToArray();
            for (var i = 0 ; i < left.Length; i++)
                result.Add(-left.Length + i, left[i]);

            result[0] = Current;

            var right = GetRight().ToArray();
            for (var i = 0; i < right.Length; i++)
                result.Add(1 + i, right[i]);

            return result;
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