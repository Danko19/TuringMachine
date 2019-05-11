using System.Collections.Generic;
using System.Linq;
using TuringMachine.Domain;
using TuringMachine.Web.Models;

namespace TuringMachine.Web.Common
{
    public static class TapeParser
    {
        public static Tape Parse(TapeItem[] items)
        {
            var itemsDict = items.ToDictionary(x => x.Index, x => x.Value);
            var min = items.Min(x => x.Index);
            var max = items.Max(x => x.Index);

            var left = new List<char>();
            var middle = new List<char>();
            var right = new List<char>();
            for (var i = min; i <= max; i++)
            {
                List<char> destination;
                if (i < 0)
                    destination = left;
                else if (i == 0)
                    destination = middle;
                else destination = right;

                if (!itemsDict.TryGetValue(i, out var item))
                    item = Tape.Placeholder;
                destination.Add(item);
            }

            return new Tape(left, middle.SingleOrDefault(), right);
        }
    }
}