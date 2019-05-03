using System;

namespace TuringMachine.Domain
{
    public enum MoveType
    {
        Left = -1,
        Stay = 0,
        Right = 1
    }

    internal static class MoveTypeExtensions
    {
        public static char ToPrettyString(this MoveType moveType)
        {
            if (moveType == MoveType.Left)
                return '←';
            if (moveType == MoveType.Stay)
                return '↓';
            if (moveType == MoveType.Right)
                return '→';

            throw new NotSupportedException($"Not supported move type {moveType}");
        }
    }
}