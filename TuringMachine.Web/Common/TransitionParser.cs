using System;
using System.Linq;
using TuringMachine.Domain;
using TuringMachine.Web.Models;

namespace TuringMachine.Web.Common
{
    public static class TransitionParser
    {
        private const string blankPlaceholder = "blank";

        public static Transition Parse(TransitionItem item)
        {
            return IsFilled(item) 
                ? new Transition(item.Word.Single(), (MoveType)Enum.Parse(typeof(MoveType), item.Move, true), item.State)
                : null;
        }

        private static bool IsFilled(TransitionItem item)
        {
            return item.Word != null
                   && item.Word != blankPlaceholder
                   && item.Move != null
                   && item.Move != blankPlaceholder
                   && item.State != null
                   && item.State != blankPlaceholder;
        }
    }
}