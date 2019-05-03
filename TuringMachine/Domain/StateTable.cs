using System;
using System.Collections.Generic;
using TuringMachine.Exceptions;

namespace TuringMachine.Domain
{
    internal class StateTable
    {
        private readonly Dictionary<string, State> states;
        public readonly string InitialState;
        public readonly string TerminalState;

        public StateTable(Dictionary<string, State> states, string initialState, string terminalState)
        {
            this.states = states ?? throw new ArgumentNullException(nameof(states));
            InitialState = initialState ?? throw new ArgumentNullException(nameof(initialState));
            TerminalState = terminalState ?? throw new ArgumentNullException(nameof(terminalState));
        }

        public State GetState(string stateName)
        {
            if (!states.TryGetValue(stateName, out var state))
                throw new NotExistingStateException(stateName);
            return state;
        }
    }
}