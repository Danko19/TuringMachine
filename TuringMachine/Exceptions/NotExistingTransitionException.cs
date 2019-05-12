using System;

namespace TuringMachine.Exceptions
{
    public class NotExistingTransitionException : Exception, ITuringMachineException
    {
        public NotExistingTransitionException(string stateName, char word)
            : base($"State '{stateName}' does not contains transition for word '{word}'")
        {
        }
    }
}