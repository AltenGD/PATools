using System.Collections.Generic;
using osuTK;
using osuTK.Graphics;
using osu.Framework.Allocation;
using osu.Framework.Extensions.IEnumerableExtensions;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Graphics.Shapes;
using StreamToolUI.Main.Graphics.UI;
using StreamToolUI.Main.Containers;

namespace StreamToolUI.Main.Overlays.Settings
{
    public abstract class SettingsOverlay : FocusedOverlayContainer
    {
        public const float CONTENT_MARGINS = 15;

        public const float TRANSITION_LENGTH = 600;

        protected const float WIDTH = 400;

        protected Container<Drawable> ContentContainer;

        protected override Container<Drawable> Content => ContentContainer;

        protected SettingsSectionsContainer SectionsContainer;

        protected Box Background;
        private StreamGameTextBox searchTextBox;

        protected SettingsOverlay()
        {
            RelativeSizeAxes = Axes.Y;
            AutoSizeAxes = Axes.X;
        }

        protected virtual IEnumerable<SettingsSection> CreateSections() => null;

        [BackgroundDependencyLoader]
        private void load()
        {
            AddInternal(ContentContainer = new Container
            {
                Width = WIDTH,
                RelativeSizeAxes = Axes.Y,
                Children = new Drawable[]
                {
                    Background = new Box
                    {
                        Anchor = Anchor.TopRight,
                        Origin = Anchor.TopRight,
                        Scale = new Vector2(2, 1),
                        RelativeSizeAxes = Axes.Both,
                        Colour = Color4.Black,
                        Alpha = 0.6f,
                    },
                    SectionsContainer = new SettingsSectionsContainer
                    {
                        Masking = true,
                        RelativeSizeAxes = Axes.Both,
                        ExpandableHeader = CreateHeader(),
                        FixedHeader = searchTextBox = new StreamGameTextBox
                        {
                            RelativeSizeAxes = Axes.X,
                            Origin = Anchor.TopCentre,
                            Anchor = Anchor.TopCentre,
                            Width = 0.95f,
                            Margin = new MarginPadding
                            {
                                Top = 20,
                                Bottom = 20
                            },
                            PlaceholderText = "Search"
                        }
                    }
                }
            });

            searchTextBox.Current.ValueChanged += term => SectionsContainer.SearchContainer.SearchTerm = term.NewValue;

            CreateSections()?.ForEach(AddSection);
        }

        protected void AddSection(SettingsSection section)
        {
            SectionsContainer.Add(section);
        }

        protected virtual Drawable CreateHeader() => new Container();

        protected override void PopIn()
        {
            base.PopIn();

            ContentContainer.MoveToX(ExpandedPosition, TRANSITION_LENGTH, Easing.OutQuint);

            this.FadeTo(1, TRANSITION_LENGTH, Easing.OutQuint);
        }

        protected virtual float ExpandedPosition => 0;

        protected override void PopOut()
        {
            base.PopOut();

            ContentContainer.MoveToX(-WIDTH, TRANSITION_LENGTH, Easing.OutQuint);

            this.FadeTo(0, TRANSITION_LENGTH, Easing.OutQuint);

            if (searchTextBox.HasFocus)
                GetContainingInputManager().ChangeFocus(null);
        }

        public override bool AcceptsFocus => true;

        protected class SettingsSectionsContainer : SectionsContainer<SettingsSection>
        {
            public SearchContainer<SettingsSection> SearchContainer;

            protected override FlowContainer<SettingsSection> CreateScrollContentContainer()
                => SearchContainer = new SearchContainer<SettingsSection>
                {
                    AutoSizeAxes = Axes.Y,
                    RelativeSizeAxes = Axes.X,
                    Direction = FillDirection.Vertical,
                };

            public SettingsSectionsContainer()
            {
                HeaderBackground = new Box
                {
                    Colour = Color4.Black,
                    RelativeSizeAxes = Axes.Both
                };
            }

            protected override void UpdateAfterChildren()
            {
                base.UpdateAfterChildren();

                // no null check because the usage of this class is strict
                HeaderBackground.Alpha = -ExpandableHeader.Y / ExpandableHeader.LayoutSize.Y * 0.5f;
            }
        }
    }
}
