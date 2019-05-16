using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Bindings;
using osu.Framework.Input.Events;
using osu.Framework.Logging;
using osu.Framework.Screens;
using osuTK;
using StreamToolUI.Main.Beatmap;
using StreamingTool.Main.Properties.PA;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using osu.Framework.Graphics.Textures;
using System.IO;
using Newtonsoft.Json;
using StreamToolUI.Main.Graphics.UI;
using StreamToolUI.Main.Extension;
using static StreamToolUI.Main.Configuration.StreamGameConfigManager;
using StreamToolUI.Main.Configuration;

namespace StreamToolUI.Main.Screens.Components
{
    public class BeatmapLevelListing : DrawSizePreservingFillContainer
    {
        private FillFlowContainer beatmapContainer;
        private List<BeatmapCard> cards;
        private TextBox searchQuery;

        [Resolved]
        private StreamGameConfigManager config { get; set; }

        public BeatmapLevelListing()
        {
            RelativeSizeAxes = Axes.Both;
            Strategy = DrawSizePreservationStrategy.Minimum;

            Children = new Drawable[]
            {
                new ScrollContainer
                {
                    RelativeSizeAxes = Axes.Both,
                    Padding = new MarginPadding
                    {
                        Top = 100,
                        Horizontal = 10,
                        Bottom = 10
                    },
                    Children = new Drawable[]
                    {
                        beatmapContainer = new FillFlowContainer
                        {
                            RelativeSizeAxes = Axes.X,
                            AutoSizeAxes = Axes.Y,
                            Direction = FillDirection.Full,
                            Spacing = new Vector2(10),
                            LayoutDuration = 100,
                            LayoutEasing = Easing.Out,
                        }
                    }
                },
            };

            cards = new List<BeatmapCard>();

            for (var i = 0; i < Directory.GetDirectories(@"C:\Program Files (x86)\Steam\steamapps\common\Project Arrhythmia\beatmaps\editor").Length; i++)
            {
                var directoryName = Directory.GetDirectories(@"C:\Program Files (x86)\Steam\steamapps\common\Project Arrhythmia\beatmaps\editor")[i];
                var BeatmapMeta = JsonConvert.DeserializeObject<PAMetadata>(File.ReadAllText(directoryName + @"\metadata.lsb"));
                var card = new BeatmapCard(BeatmapMeta);

                card.index = i;
                card.Directory = directoryName;

                if (File.Exists(directoryName + @"\banner.jpg"))
                {
                    FileStream image = File.OpenRead(directoryName + @"\banner.jpg");
                    card.Background.Texture = Texture.FromStream(image);
                    image.Close();
                }
                else if (File.Exists(directoryName + @"\level.jpg"))
                {
                    FileStream image = File.OpenRead(directoryName + @"\level.jpg");
                    card.Background.Texture = Texture.FromStream(image);
                    image.Close();
                }
                else
                {
                    FileStream image = File.OpenRead(@"C:\Program Files (x86)\Steam\steamapps\common\Project Arrhythmia\beatmaps\editor\default.jpg");
                    card.Background.Texture = Texture.FromStream(image);
                    image.Close();
                }

                cards.Add(card);
            }

            /*foreach (var c in cards)
            {
                beatmapContainer.Add(cards[c.index]);

                cards[c.index].Selected.ValueChanged += obj =>
                {
                    if (obj.NewValue)
                        foreach (var j in cards)
                            if (j != cards[c.index] && j.Selected.Value)
                                j.Selected.Value = false;
                };
            }*/

                    beatmapContainer.AddRange(cards);
        }

        protected override void LoadComplete()
        {
            Add(searchQuery = new StreamGameTextBox
            {
                RelativeSizeAxes = Axes.X,
                Size = new Vector2(0.99f, 50),
                Origin = Anchor.TopCentre,
                Anchor = Anchor.TopCentre,
                Margin = new MarginPadding(10)
            });

            searchQuery.OnCommit = delegate
            {
                foreach (var c in cards)
                    if (searchQuery.Current.Value.MatchesSearchCriteria(c.meta.Song.Title))
                        c.Show();
                    else
                        c.Hide();
            };

            base.LoadComplete();
        }
    }
}
