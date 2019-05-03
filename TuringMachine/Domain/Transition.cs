using System;

namespace TuringMachine.Domain
{
    public class Transition
    {
        public Transition(char setWord, MoveType moveType, string nextState)
        {
            SetWord = setWord;
            MoveType = moveType;
            NextState = nextState ?? throw new ArgumentNullException(nameof(nextState));
        }

        public char SetWord { get; }
        public MoveType MoveType { get; }
        public string NextState { get; }

        public override string ToString()
        {
            return $"{SetWord}{MoveType.ToPrettyString()}{NextState}";
        }
    }
}