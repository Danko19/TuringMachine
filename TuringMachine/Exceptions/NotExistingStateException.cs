using System;

namespace TuringMachine.Exceptions
{
    public class NotExistingStateException : Exception, ITuringMachineException
    {
        public NotExistingStateException(string stateName)
            : base($"State '{stateName}' does not exists")
        {
        }
    }
}