using Newtonsoft.Json;

namespace StreamingTool.Main.Properties.PA
{
    public class PACBeatmap
    {
        [JsonProperty("Date_edited")]
        public string DateEdited { get; set; }

        /// <summary>string because of "MajorVersion.MinorVersion.Build"</summary>
        [JsonProperty("Game_version")]
        public string GameVersion { get; set; }

        [JsonProperty("Version_number")]
        public int VersionNumber { get; set; }

        [JsonProperty("Workshop_id")]
        public int WorkshopID { get; set; }
    }
}