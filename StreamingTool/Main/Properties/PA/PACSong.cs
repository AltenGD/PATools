using Newtonsoft.Json;

namespace StreamingTool.Main.Properties.PA
{
    public class PACSong
    {
        public string Title { get; set; }

        public int Difficulty { get; set; }

        public string Description { get; set; }

        public double bpm { get; set; }

        [JsonProperty("t")]
        public double StartTime { get; set; }
    }
}