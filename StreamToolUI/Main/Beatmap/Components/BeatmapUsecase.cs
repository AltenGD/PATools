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
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StreamToolUI.Main.Graphics.Colors;
using StreamToolUI.Main.Graphics.Sprites;
using StreamingTool.Main.Properties;
using StreamingTool.Main.Properties.PA;
using osuTK.Graphics;
using osu.Framework.Graphics.Cursor;

namespace StreamToolUI.Main.Beatmap.Components
{
    public class BeatmapUsecase : Container
    {
        private PAMetadata meta;
        private Color4 difficultyColor;
        private TextFlowContainer textContainer;
        private Button useButton;

        public Action Select;
        public BindableBool Selected = new BindableBool(false);

        public BeatmapUsecase(PAMetadata Metadata)
        {
            meta = Metadata;

            switch (meta.Song.Difficulty)
            {
                case 0:
                    difficultyColor = StreamToolColors.Easy;
                    break;
                case 1:
                    difficultyColor = StreamToolColors.Normal;
                    break;
                case 2:
                    difficultyColor = StreamToolColors.Hard;
                    break;
                case 3:
                    difficultyColor = StreamToolColors.Expert;
                    break;
                case 4:
                    difficultyColor = StreamToolColors.ExpertPlus;
                    break;
                default:
                    difficultyColor = StreamToolColors.Unknown;
                    break;
            }

            Children = new Drawable[]
            {
                new Box
                {
                    RelativeSizeAxes = Axes.Both
                },
                new Box
                {
                    RelativeSizeAxes = Axes.X,
                    Size = new Vector2(1f, 5),
                    Colour = difficultyColor,
                    Origin = Anchor.BottomCentre,
                    Anchor = Anchor.BottomCentre
                },
                new Container
                {
                    Padding = new MarginPadding(5),
                    RelativeSizeAxes = Axes.Both,
                    Children = new Drawable[]
                    {
                        textContainer = new TextFlowContainer
                        {
                            Direction = FillDirection.Horizontal
                        },
                        useButton = new Button
                        {
                            BackgroundColour = StreamToolColors.Primary,
                            Text = "Set",
                            Anchor = Anchor.TopRight,
                            Origin = Anchor.TopRight,
                            CornerRadius = 5,
                            Masking = true,
                            Size = new Vector2(50, 23),
                            Action = () => 
                            {
                                Select?.Invoke();
                                Selected.Value = !Selected.Value;
                                //useButton.TransformTo(nameof(useButton.BackgroundColour), Selected.Value ? StreamToolColors.Used : StreamToolColors.Primary, 200);
                            }
                        }
                    }
                }
            };

            textContainer.AddText(new SpriteText
            {
                Text = "mapped by ",
                Colour = Color4.Black
            });

            textContainer.AddText(new SpriteTextLink("https://github.com/ppy/osu/blob/master/osu.Game/Users/User.cs")
            {
                Text = meta.Creator.Name
            });
        }
    }
}
