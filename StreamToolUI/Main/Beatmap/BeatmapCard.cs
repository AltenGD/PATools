using osu.Framework.Allocation;
using osu.Framework.Bindables;
using osu.Framework.Extensions.Color4Extensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Colour;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Effects;
using osu.Framework.Graphics.Shapes;
using osu.Framework.Graphics.Sprites;
using osu.Framework.Graphics.Textures;
using osu.Framework.Graphics.UserInterface;
using osu.Framework.Input.Bindings;
using osu.Framework.Input.Events;
using osu.Framework.Logging;
using osu.Framework.Screens;
using osuTK;
using osuTK.Graphics;
using StreamingTool.Main.Properties.PA;
using StreamToolUI.Main.Beatmap.Components;
using StreamToolUI.Main.Graphics.Sprites;
using StreamToolUI.Main.Screens;
using StreamToolUI.Main.Screens.Backgrounds;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Threading.Tasks;

using static StreamToolUI.Main.Graphics.Sprites.StreamGameFont;

namespace StreamToolUI.Main.Beatmap
{
    public class BeatmapCard : Container
    {
        private Vector2 size = new Vector2(330, 150);
        private BeatmapUsecase beatmapUseCase;

        [Resolved(canBeNull: true)]
        private BackgroundScreenStack backgroundStack { get; set; }

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

        private void Select(ValueChangedEvent<bool> value)
        {
            /*EdgeEffectParameters selectedParams = new EdgeEffectParameters
            {
                Type = EdgeEffectType.Shadow,
                Offset = new Vector2(0f, 4f),
                Radius = 0.1f,
                Colour = Color4.Black.Opacity(0.3f),
            };

            EdgeEffectParameters deselectedParams = new EdgeEffectParameters
            {
                Type = EdgeEffectType.Shadow,
                Offset = new Vector2(0f, 2f),
                Radius = 1f,
                Colour = Color4.Black.Opacity(0.25f),
            };*/

            switch (value.NewValue)
            {
                case true:
                    //TweenEdgeEffectTo(selectedParams, 500, Easing.OutExpo);
                    SetBeatmap(meta);
                    break;
                case false:
                    //TweenEdgeEffectTo(deselectedParams, 500, Easing.OutExpo);
                    break;
            }

            if (Directory != null)
            {
                if (File.Exists(Directory + @"\banner.jpg"))
                {
                    backgroundStack.Push(new BackgroundScreenBlack());
                    FileStream image = File.Open(Directory + @"\banner.jpg", FileMode.Open);
                    var background = new BackgroundScreenCustom(image);
                    backgroundStack.Push(background);
                    background.OnLoadComplete += _ =>
                    {
                        image.Close();
                    };
                }
                else if (File.Exists(Directory + @"\level.jpg"))
                {
                    backgroundStack.Push(new BackgroundScreenBlack());
                    FileStream image = File.Open(Directory + @"\level.jpg", FileMode.Open);
                    var background = new BackgroundScreenCustom(image);
                    backgroundStack.Push(background);
                    background.OnLoadComplete += _ =>
                    {
                        image.Close();
                    };
                }
                else
                {
                    backgroundStack.Push(new BackgroundScreenDefault());
                }
            }
        }

        private void SetBeatmap(PAMetadata meta)
        {
            //TODO: Setting
            var directory = @"D:\PAStream\Beatmap\";

            //Artist
            File.WriteAllText(directory + @"artist\link.txt", meta.Artist.Link);
            File.WriteAllText(directory + @"artist\name.txt", meta.Artist.Name);

            //Beatmap
            File.WriteAllText(directory + @"beatmap\date_edited.txt", meta.Beatmap.Date_edited);
            File.WriteAllText(directory + @"beatmap\game_version.txt", meta.Beatmap.Game_version);
            File.WriteAllText(directory + @"beatmap\version_number.txt", meta.Beatmap.Version_number.ToString());
            File.WriteAllText(directory + @"beatmap\workshop_id.txt", meta.Beatmap.Workshop_id.ToString());

            //Creator
            File.WriteAllText(directory + @"creator\steam_id.txt", meta.Creator.Steam_id.ToString());
            File.WriteAllText(directory + @"creator\steam_name.txt", meta.Creator.Steam_name);

            //Song
            File.WriteAllText(directory + @"song\bpm.txt", meta.Song.bpm.ToString());
            File.WriteAllText(directory + @"song\description.txt", meta.Song.Description);
            File.WriteAllText(directory + @"song\difficulty.txt", meta.Song.Difficulty.ToString()); //TODO: format this
            File.WriteAllText(directory + @"song\t.txt", meta.Song.t.ToString());
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
                        bm = new System.Drawing.Bitmap(@"C:\Program Files (x86)\Steam\steamapps\common\Project Arrhythmia\beatmaps\editor\default.jpg");

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