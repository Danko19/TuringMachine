using System.Collections.Generic;
using System.Linq;
using TuringMachine.Domain;
using TuringMachine.Exceptions;

namespace TuringMachine.Builders
{
    public class TuringMachineBuilder
    {
        private readonly HashSet<char> alphabet;
        private readonly StateTableBuilder stateTableBuilder;
        private TapeProvider tapeProvider;

        public TuringMachineBuilder(params char[] alphabet)
        {
            this.alphabet = new HashSet<char>(alphabet.Append(Tape.Placeholder));
            stateTableBuilder = new StateTableBuilder(this.alphabet);
        }

        public StateTableBuilder ConfigureStateTable()
        {
            return stateTableBuilder;
        }

        public TuringMachineBuilder SetupTape(Tape tape)
        {
            if (tape.Any(word => !alphabet.Contains(word)))
                throw new OutOfAlphabetWordException(tape.FirstOrDefault(word => !alphabet.Contains(word)));
            tapeProvider = new TapeProvider(tape);
            return this;
        }

        public Domain.TuringMachine Build()
        {
            return new Domain.TuringMachine(tapeProvider ?? new TapeProvider(new Tape()), stateTableBuilder.Build());
        }
    }
}