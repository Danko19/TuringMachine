using System;

namespace TuringMachine.Exceptions
{
    public class TransitionAlreadyExistsException : Exception, ITuringMachineException
    {
        public TransitionAlreadyExistsException(char word)
            : base($"Transition for '{word}' already exists")
        {
        }
    }
}