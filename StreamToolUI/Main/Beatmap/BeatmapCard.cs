using osu.Framework.Allocation;
using osu.Framework.Audio.Track;
using osu.Framework.Bindables;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Effects;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osuTK;
using osuTK.Graphics;
using StreamingTool.Main.Properties.PA;
using StreamToolUI.Main.Beatmap.Components;
using StreamToolUI.Main.Configuration;
using StreamToolUI.Main.Screens;
using StreamToolUI.Main.Screens.Backgrounds;
using System;
using System.Drawing.Imaging;
using System.IO;
using static StreamToolUI.Main.Configuration.StreamGameConfigManager;
using static StreamToolUI.Main.Graphics.Sprites.StreamGameFont;

namespace StreamToolUI.Main.Beatmap
{
    public class BeatmapCard : Container
    {
        private Vector2 size = new Vector2(330, 150);
        private BeatmapUsecase beatmapUseCase;
        private Bindable<bool> changeBackground;

        [Resolved(canBeNull: true)]
        private BackgroundScreenStack backgroundStack { get; set; }

        [Resolved]
        private StreamGameConfigManager config { get; set; }

        public PAMetadata meta;
        public Box Background;
        public FileStream ImageFile;
        public BindableBool Selected = new BindableBool(false);
        public Action SelectAction;
        public int index;
        public string Directory;

        public BeatmapCard(PAMetadata Metadata)
        {
            meta = Metadata;
            Size = size;
            CornerRadius = 5;
            Masking = true;

            EdgeEffect = new EdgeEffectParameters
            {
                Type = EdgeEffectType.Shadow,
                Offset = new Vector2(0f, 2f),
                Radius = 1f,
                Colour = Color4.Black.Opacity(0.25f),
            };

            Children = new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = Color4.Black
                },
                Background = new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    FillMode = FillMode.Fill,
                    Anchor = Anchor.Centre,
                    Origin = Anchor.Centre,
                    Alpha = 0.6f
                },
                new Box
                {
                    RelativeSizeAxes = Axes.Both,
                    Colour = new ColourInfo
                    {
                        TopLeft = Color4.Black.Opacity(0f),
                        TopRight = Color4.Black.Opacity(0f),
                        BottomLeft = Color4.Black.Opacity(0.6f),
                        BottomRight = Color4.Black.Opacity(0.6f)
                    }
                },
                new FillFlowContainer
                {
                    RelativeSizeAxes = Axes.Both,
                    Direction = FillDirection.Vertical,
                    Anchor = Anchor.BottomCentre,
                    Origin = Anchor.BottomCentre,
                    Padding = new MarginPadding
                    {
                        Bottom = size.Y / 4 + 5,
                        Left = 5
                    },
                    Children = new Drawable[]
                    {
                        new SpriteText
                        {
                            Text = meta.Artist.Name,
                            Font = GetFont(Typeface.Neogrey, 20, FontWeight.Medium),
                            Anchor = Anchor.BottomLeft,
                            Origin = Anchor.BottomLeft
                        },
                        new SpriteText
                        {
                            Text = meta.Song.Title,
                            Font = GetFont(Typeface.Neogrey, 30, FontWeight.Medium),
                            Anchor = Anchor.BottomLeft,
                            Origin = Anchor.BottomLeft
                        }
                    }
                },
                beatmapUseCase = new BeatmapUsecase(meta)
                {
                    Origin = Anchor.BottomLeft,
                    Anchor = Anchor.BottomLeft,
                    RelativeSizeAxes = Axes.X,
                    Size = new Vector2(1f, size.Y / 4),
                    Select = () => Selected.Value = !Selected.Value,
                }
            };

            Selected.ValueChanged += Select;
        }

        protected override void LoadComplete()
        {
            changeBackground = new Bindable<bool>(true);
            changeBackground = config.GetBindable<bool>(StreamGameSettings.ChangeBackground);

            changeBackground.ValueChanged += change =>
            {
                if (!change.NewValue)
                    backgroundStack.Push(new BackgroundScreenDefault());
            };

            FileStream music = File.OpenRead(Directory + @"\level.ogg");
            PlayButton button;

            Add(button = new PlayButton(new TrackBass(music) { Looping = true })
            {
                Size = new Vector2(30),
                Margin = new MarginPadding(10)
            });

            base.LoadComplete();
        }

        private void Select(ValueChangedEvent<bool> value)
        {

            switch (value.NewValue)
            {
                case true:
                    SetBeatmap(meta);
                    break;
                case false:
                    break;
            }

            if (Directory != null)
            {
                if (changeBackground.Value)
                {
                    if (File.Exists(Directory + @"\banner.jpg"))
                    {
                        backgroundStack.Push(new BackgroundScreenBlack());
                        FileStream image = File.OpenRead(Directory + @"\banner.jpg");
                        var background = new BackgroundScreenCustom(image);
                        backgroundStack.Push(background);
                    }
                    else if (File.Exists(Directory + @"\level.jpg"))
                    {
                        backgroundStack.Push(new BackgroundScreenBlack());
                        FileStream image = File.OpenRead(Directory + @"\level.jpg");
                        var background = new BackgroundScreenCustom(image);
                        backgroundStack.Push(background);
                    }
                    else
                    {
                        backgroundStack.Push(new BackgroundScreenDefault());
                    }
                }
            }
        }

        private void SetBeatmap(PAMetadata meta)
        {
            //TODO: Setting
            var directory = config.Get<string>(StreamGameSettings.StreamDirectory);

            if (!directory.EndsWith(@"\"))
                directory += @"\";

            //Artist
            File.WriteAllText(directory + @"artist\link.txt", meta.Artist.Link);
            File.WriteAllText(directory + @"artist\name.txt", meta.Artist.Name);

            //Beatmap
            File.WriteAllText(directory + @"beatmap\date_edited.txt", meta.Beatmap.DateEdited);
            File.WriteAllText(directory + @"beatmap\game_version.txt", meta.Beatmap.GameVersion);
            File.WriteAllText(directory + @"beatmap\version_number.txt", meta.Beatmap.VersionNumber.ToString());
            File.WriteAllText(directory + @"beatmap\workshop_id.txt", meta.Beatmap.WorkshopID.ToString());

            //Creator
            File.WriteAllText(directory + @"creator\steam_id.txt", meta.Creator.ID.ToString());
            File.WriteAllText(directory + @"creator\steam_name.txt", meta.Creator.Name);

            //Song
            File.WriteAllText(directory + @"song\bpm.txt", meta.Song.bpm.ToString());
            File.WriteAllText(directory + @"song\description.txt", meta.Song.Description);
            File.WriteAllText(directory + @"song\difficulty.txt", meta.Song.Difficulty.ToString()); //TODO: format this
            File.WriteAllText(directory + @"song\t.txt", meta.Song.StartTime.ToString());
            File.WriteAllText(directory + @"song\title.txt", meta.Song.Title);

            System.Drawing.Bitmap bm;

            if (Directory != null)
            {
                try
                {
                    if (File.Exists(Directory + @"\banner.jpg"))
                        bm = new System.Drawing.Bitmap(Directory + @"\banner.jpg");
                    else if (File.Exists(Directory + @"\level.jpg"))
                        bm = new System.Drawing.Bitmap(Directory + @"\level.jpg");
                    else
                        bm = new System.Drawing.Bitmap(config.Get<string>(StreamGameSettings.DefaultImage));

                    if (File.Exists(directory + "image.png"))
                        File.Delete(directory + "image.png");

                    bm.Save(directory + "image.png", ImageFormat.Png);
                    bm.Dispose();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}