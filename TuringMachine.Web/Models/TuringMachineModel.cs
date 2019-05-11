using Newtonsoft.Json;
using TuringMachine.Domain;

namespace TuringMachine.Web.Models
{
    public class TuringMachineModel
    {
        [JsonProperty(PropertyName = "tape")]
        public TapeItem[] Tape { get; set; }
        [JsonProperty(PropertyName = "alphabet")]
        public char[] Alphabet { get; set; }
        [JsonProperty(PropertyName = "states")]
        public string[] States { get; set; }
        [JsonProperty(PropertyName = "transitions")]
        public TransitionItem[] Transitions { get; set; }
        [JsonProperty(PropertyName = "executingSnapshots")]
        public ExecutingSnapshot[] ExecutingSnapshots { get; set; }
    }

    public class TapeItem
    {
        [JsonProperty(PropertyName = "index")]
        public int Index { get; set; }
        [JsonProperty(PropertyName = "value")]
        public char Value { get; set; }
    }

    public class TransitionItem
    {
        [JsonProperty(PropertyName = "word")]
        public string Word { get; set; }
        [JsonProperty(PropertyName = "move")]
        public string Move { get; set; }
        [JsonProperty(PropertyName = "state")]
        public string State { get; set; }
    }
}