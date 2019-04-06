using StreamingTool.Main.Properties;
using StreamingTool.Main.Properties.PA;
using System.IO;
using Newtonsoft.Json;

namespace StreamingTool.Main
{
    public class BeatmapManager
    {
        public BeatmapManager()
        {
            //will all default to either "" or null
            //TODO: add text to inform the user
            CurrentInfo.Info = new PAMetadata
            {
                Artist = new PAArtist(),
                Beatmap = new PACBeatmap(),
                Creator = new PACreator(),
                Song = new PACSong()
            };
        }

        public void setBeatmap(int index, string lvlFolder)
        {
            try
            {
                var BeatmapFolder = Directory.GetDirectories(lvlFolder)[index];
                var BeatmapMeta = JsonConvert.DeserializeObject<PAMetadata>(File.ReadAllText(BeatmapFolder + @"\metadata.lsb"));

                CurrentInfo.Info = BeatmapMeta;
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("Invalid Beatmap Index");
            }
        }
    }
}
