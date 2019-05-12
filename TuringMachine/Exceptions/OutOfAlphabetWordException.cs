using System;

namespace TuringMachine.Exceptions
{
    public class OutOfAlphabetWordException : Exception, ITuringMachineException
    {
        public OutOfAlphabetWordException(char word)
            : base($"Alphabet does not contains word '{word}'")
        {
        }
    }
}