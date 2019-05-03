using System;
using System.Linq;

namespace TuringMachine.Domain
{
    public class ExecutingSnapshot
    {
        internal ExecutingSnapshot(Tape tape, Transition lastTransition)
        {
            if (tape == null)
                throw new ArgumentNullException(nameof(tape));
            Left = tape.GetLeft().ToArray();
            Current = tape.Current;
            Right = tape.GetRight().ToArray();
            LastTransition = lastTransition ?? throw new ArgumentNullException(nameof(lastTransition));
        }

        public char[] Left { get; }
        public char Current { get; }
        public char[] Right { get; }
        public Transition LastTransition { get; }
    }
}