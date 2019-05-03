using System;

namespace TuringMachine.Exceptions
{
    public class NotExistingStateException : Exception
    {
        public NotExistingStateException(string stateName)
            : base($"State '{stateName}' does not exists")
        {
        }
    }
}