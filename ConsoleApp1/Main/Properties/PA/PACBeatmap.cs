namespace StreamingTool.Main.Properties.PA
{
    public class PACBeatmap
    {
        public string Date_edited { get; set; }

        /// <summary>string because of "MajorVersion.MinorVersion.Build"</summary>
        public string Game_version { get; set; }

        public int Version_number { get; set; }

        public int Workshop_id { get; set; }
    }
}