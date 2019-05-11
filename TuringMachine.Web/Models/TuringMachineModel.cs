using System;
using System.Linq;
using TuringMachine.Domain;

namespace TuringMachine.Web.Models
{
    public class TuringMachineModel
    {
        public TapeItem[] Tape { get; set; }
        public char[] Alphabet { get; set; }
        public string[] States { get; set; }
        public TransitionItem[] Transitions { get; set; }
    }

    public class TapeItem
    {
        public int Index { get; set; }
        public char Value { get; set; }
    }

    public class TransitionItem
    {
        public string Word { get; set; }
        public string Move { get; set; }
        public string State { get; set; }
    }
}