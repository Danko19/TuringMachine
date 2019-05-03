using System;

namespace TuringMachine.Exceptions
{
    public class StateAlreadyExistsException : Exception
    {
        public StateAlreadyExistsException(string stateName)
            : base($"State '{stateName}' already exists")
        {
        }
    }
}