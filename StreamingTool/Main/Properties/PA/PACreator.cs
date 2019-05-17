using Newtonsoft.Json;

namespace StreamingTool.Main.Properties.PA
{
    public class PACreator
    {
        [JsonProperty("Steam_name")]
        public string Name { get; set; } = "Unknown Creator";

        [JsonProperty("Steam_id")]
        public int ID { get; set; }
    }
}