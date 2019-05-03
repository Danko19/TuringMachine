using System;

namespace TuringMachine.Exceptions
{
    public class TerminalStateReachedException : Exception
    {
        public TerminalStateReachedException(string stateName)
            : base($"State {stateName} is a terminal, transitions are not allowed")
        {
        }
    }
}