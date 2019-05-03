using System;

namespace TuringMachine.Domain
{
    internal class TapeProvider
    {
        private readonly Tape tape;

        public TapeProvider(Tape tape)
        {
            this.tape = tape ?? throw new ArgumentNullException(nameof(tape));
        }

        public Tape GetTape()
        {
            return new Tape(tape);
        }
    }
}