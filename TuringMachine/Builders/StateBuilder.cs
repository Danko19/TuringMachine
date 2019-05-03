using System.Collections.Generic;
using TuringMachine.Domain;
using TuringMachine.Exceptions;

namespace TuringMachine.Builders
{
    public class StateBuilder
    {
        private readonly HashSet<char> alphabet;
        private readonly string stateName;
        private readonly Dictionary<char, Transition> transitions = new Dictionary<char, Transition>();

        internal StateBuilder(HashSet<char> alphabet, string stateName)
        {
            this.alphabet = alphabet;
            this.stateName = stateName;
        }

        public StateBuilder AddTransition(char word, Transition transition)
        {
            if (!alphabet.Contains(word))
                throw new OutOfAlphabetWordException(word);
            if (transitions.ContainsKey(word))
                throw new TransitionAlreadyExistsException(word);
            transitions.Add(word, transition);
            return this;
        }

        internal State Build()
        {
            return new State(stateName, transitions);
        }
    }
}