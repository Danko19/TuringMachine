using System;
using System.Collections.Generic;
using TuringMachine.Exceptions;

namespace TuringMachine.Domain
{
    internal class State
    {
        private readonly Dictionary<char, Transition> transitions;

        public State(string name, Dictionary<char, Transition> transitions)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            this.transitions = transitions ?? throw new ArgumentNullException(nameof(transitions));
        }

        public string Name { get; }

        public Transition GetTransition(char word)
        {
            if (!transitions.TryGetValue(word, out var transition))
                throw new NotExistingTransitionException(Name, word);
            return transition;
        }
    }
}