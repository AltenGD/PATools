using Newtonsoft.Json;

namespace StreamingTool.Main.Properties.PA
{
    public class PACSong
    {
        public string Title { get; set; } = "Unknown Title";

        public int Difficulty { get; set; } = 0;

        public string Description { get; set; } = "Unknown Description";

        public double bpm { get; set; }

        [JsonProperty("t")]
        public double StartTime { get; set; }
    }
}