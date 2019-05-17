using osu.Framework.Allocation;
using osu.Framework.Graphics;
using System.IO;
using StreamToolUI.Main.Configuration;
using static StreamToolUI.Main.Configuration.StreamGameConfigManager;
using System;
using osu.Framework.Logging;

namespace StreamToolUI.Main.Overlays.Settings.Sections.General
{
    public class GenBeatmap : SettingsSubsection
    {
        protected override string Header => "Beatmap";

        [Resolved]
        private StreamGameConfigManager config { get; set; }

        [BackgroundDependencyLoader]
        private void load()
        {
            Children = new Drawable[]
            {
                new SettingsButton
                {
                    Text = "Create necessary folders",
                    Action = () =>
                    {
                        try
                        {
                            //Artist
                            string artistLink = @"artist\link.txt";
                            string artistName = @"artist\name.txt";

                            //Beatmap
                            string beatmapDateEdited = @"beatmap\date_edited.txt";
                            string beatmapGameVersion = @"beatmap\game_version.txt";
                            string beatmapVersionNumber = @"beatmap\version_number.txt";
                            string beatmapWorkshopId = @"beatmap\workshop_id.txt";

                            //Creator
                            string creatorSteamID = @"creator\steam_id.txt";
                            string creatorSteamName = @"creator\steam_name.txt";

                            //Song
                            string songBpm = @"song\bpm.txt";
                            string songDescription = @"song\description.txt";
                            string songDifficulty = @"song\difficulty.txt";
                            string songT = @"song\t.txt";
                            string songTitle = @"song\title.txt";

                            //Create all files & Makes sure to not have duplicates
                            //Artist
                            CreateFolderAndFile(artistLink);
                            CreateFolderAndFile(artistName);

                            //Beatmap
                            CreateFolderAndFile(beatmapDateEdited);
                            CreateFolderAndFile(beatmapGameVersion);
                            CreateFolderAndFile(beatmapVersionNumber);
                            CreateFolderAndFile(beatmapWorkshopId);

                            //Creator
                            CreateFolderAndFile(creatorSteamID);
                            CreateFolderAndFile(creatorSteamName);

                            //Song
                            CreateFolderAndFile(songBpm);
                            CreateFolderAndFile(songDescription);
                            CreateFolderAndFile(songDifficulty);
                            CreateFolderAndFile(songT);
                            CreateFolderAndFile(songTitle);
                        }
                        catch (Exception e)
                        {
                            Logger.Log(e.Message);
                        }
                    }
                }
            };
        }

        private void CreateFolderAndFile(string path)
        {
            var directory = config.Get<string>(StreamGameSettings.StreamDirectory);

            if (!directory.EndsWith(@"\"))
                directory += @"\";

            var files = path.Split(@"\");

            var folder = files[0];
            var file = files[1];

            if (!System.IO.Directory.Exists(directory + folder))
            {
                System.IO.Directory.CreateDirectory(directory + folder);
            }

            Console.WriteLine(System.IO.Directory.Exists(directory + folder));

            if (!File.Exists(directory + folder + @"\" + file))
            {
                File.Create($@"{(directory + folder + @"\" + file).ToString()}");
            }
        }
    }
}
