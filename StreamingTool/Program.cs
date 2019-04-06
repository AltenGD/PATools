using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using StreamingTool.Main.Properties;
using StreamingTool.Main.Properties.PA;
using StreamingTool.Main;

namespace StreamingTool
{
    public class Program
    {
        private static string PADir = @"C:\Program Files (x86)\Steam\steamapps\common\Project Arrhythmia\";
        /// <summary>You are free to change this to any directory you want.</summary>
        private static string STRDir = @"D:\PAStream\Beatmap\";
        private static string PALvl = PADir + @"beatmaps\editor";
        private static string PAPre = PADir + @"beatmaps\prefabs";
        private static string PAThe = PADir + @"beatmaps\themes";

        private static BeatmapManager Manager;

        public static void Main()
        {
            Manager = new BeatmapManager();

            Console.WriteLine("Awaiting keypresses.");

            //Give us an infinite loop
            while (true)
            {
                var Index = Console.ReadLine();

                int.TryParse(Index, out int intIndex);

                Manager.setBeatmap(intIndex, PALvl);

                var start = DateTime.Now;

                //Artist
                File.WriteAllText(STRDir + @"artist\link.txt", CurrentInfo.Info.Artist.Link);
                File.WriteAllText(STRDir + @"artist\name.txt", CurrentInfo.Info.Artist.Name);

                //Beatmap
                File.WriteAllText(STRDir + @"beatmap\date_edited.txt", CurrentInfo.Info.Beatmap.Date_edited);
                File.WriteAllText(STRDir + @"beatmap\game_version.txt", CurrentInfo.Info.Beatmap.Game_version);
                File.WriteAllText(STRDir + @"beatmap\version_number.txt", CurrentInfo.Info.Beatmap.Version_number.ToString());
                File.WriteAllText(STRDir + @"beatmap\workshop_id.txt", CurrentInfo.Info.Beatmap.Workshop_id.ToString());

                //Creator
                File.WriteAllText(STRDir + @"creator\steam_id.txt", CurrentInfo.Info.Creator.Steam_id.ToString());
                File.WriteAllText(STRDir + @"creator\steam_name.txt", CurrentInfo.Info.Creator.Steam_name);

                //Song
                File.WriteAllText(STRDir + @"song\bpm.txt", CurrentInfo.Info.Song.bpm.ToString());
                File.WriteAllText(STRDir + @"song\description.txt", CurrentInfo.Info.Song.Description);
                File.WriteAllText(STRDir + @"song\difficulty.txt", CurrentInfo.Info.Song.Difficulty.ToString()); //TODO: format this
                File.WriteAllText(STRDir + @"song\t.txt", CurrentInfo.Info.Song.t.ToString());
                File.WriteAllText(STRDir + @"song\title.txt", CurrentInfo.Info.Song.Title);

                var end = DateTime.Now;

                Console.WriteLine($"Completed in under {end - start}ms");
            }
        }
    }
}

/// How's this going to work:
/// Check which level it is going to be (cmd)
/// Check the contents
/// Changes stream data, etc
/// Edits image a bit (cover image) ?? default PA image
/// Publish to github
/// Done.