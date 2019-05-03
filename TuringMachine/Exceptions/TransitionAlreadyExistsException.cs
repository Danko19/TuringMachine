using System;

namespace TuringMachine.Exceptions
{
    public class TransitionAlreadyExistsException : Exception
    {
        public TransitionAlreadyExistsException(char word)
            : base($"Transition for '{word}' already exists")
        {
        }
    }
}