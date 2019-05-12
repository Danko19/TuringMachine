using System;

namespace TuringMachine.Exceptions
{
    public class StateAlreadyExistsException : Exception, ITuringMachineException
    {
        public StateAlreadyExistsException(string stateName)
            : base($"State '{stateName}' already exists")
        {
        }
    }
}