using System.Collections.Generic;
using System.Linq;
using TuringMachine.Domain;
using TuringMachine.Exceptions;

namespace TuringMachine.Builders
{
    public class StateTableBuilder
    {
        private readonly HashSet<char> alphabet;
        private readonly Dictionary<string, StateBuilder> stateBuilders = new Dictionary<string, StateBuilder>();
        private string initialState;
        private string terminalState;

        public StateTableBuilder(HashSet<char> alphabet)
        {
            this.alphabet = alphabet;
        }

        public StateBuilder AddState(string stateName)
        {
            if(stateBuilders.ContainsKey(stateName))
                throw new StateAlreadyExistsException(stateName);
            var stateBuilder = new StateBuilder(alphabet, stateName);
            stateBuilders.Add(stateName, stateBuilder);
            return stateBuilder;
        }

        public StateBuilder AddInitialState(string stateName)
        {
            if (initialState != null)
                throw new StateAlreadyExistsException("initial state");
            initialState = stateName;
            return AddState(stateName);
        }

        public StateTableBuilder AddTerminalState(string stateName)
        {
            if (terminalState != null)
                throw new StateAlreadyExistsException("terminal state");
            terminalState = stateName;
            AddState(stateName);
            return this;
        }

        internal StateTable Build()
        {
            var states = stateBuilders.ToDictionary(x => x.Key, y => y.Value.Build());
            return new StateTable(states, initialState, terminalState);
        }
    }
}