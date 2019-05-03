using System;
using System.Collections.Generic;

namespace TuringMachine.Domain
{
    public class TuringMachine
    {
        private readonly TapeProvider tapeProvider;
        private readonly StateTable table;

        internal TuringMachine(TapeProvider tapeProvider, StateTable table)
        {
            this.tapeProvider = tapeProvider ?? throw new ArgumentNullException(nameof(tapeProvider));
            this.table = table ?? throw new ArgumentNullException(nameof(table));
        }

        public IEnumerable<ExecutingSnapshot> ExecuteWithSnapshots()
        {
            var state = table.InitialState;
            var tape = tapeProvider.GetTape();
            while (state != table.TerminalState)
            {
                var transition = table.GetState(state).GetTransition(tape.Current);
                state = Execute(tape, transition);
                yield return new ExecutingSnapshot(tape, transition);
            }
        }

        private static string Execute(Tape tape, Transition transition)
        {
            tape.Current = transition.SetWord;
            if (transition.MoveType == MoveType.Left)
                tape.MoveLeft();
            if (transition.MoveType == MoveType.Right)
                tape.MoveRight();
            return transition.NextState;
        }
    }
}