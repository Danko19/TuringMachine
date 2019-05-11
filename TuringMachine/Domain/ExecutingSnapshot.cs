using System;
using System.Collections.Generic;

namespace TuringMachine.Domain
{
    public class ExecutingSnapshot
    {
        internal ExecutingSnapshot(Tape tape, Transition lastTransition)
        {
            if (tape == null)
                throw new ArgumentNullException(nameof(tape));
            Tape = tape.ToDictionary();
            LastTransition = lastTransition ?? throw new ArgumentNullException(nameof(lastTransition));
        }

        public Dictionary<int, char> Tape { get; }
        public Transition LastTransition { get; }
    }
}