using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using TetrisEmpire.Components.UI;

namespace TetrisEmpire.Components.Rooms
{
    public class MenuRoom : AbstractRoom
    {
        private Texture2D tileTexture;
        private SpriteFont buttonFont;
        public List<AbstractDrawableComponent> Components { get; private set; }


        public MenuRoom(MainGame game) : base(game) { }

        public override void Initialize()
        {
            Components = new List<AbstractDrawableComponent>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            tileTexture = Content.Load<Texture2D>("images/tetrisTile");
            buttonFont = Content.Load<SpriteFont>("fonts/button");

            int buttonWidth = WorldWidth / 3;
            int buttonHeight = buttonWidth / 5;

            Components.Add(new TextButton(
                MainGame,
                new Rectangle(20, WorldHeight - (20 + buttonHeight), buttonWidth, buttonHeight),
                buttonFont,
                "Exit",
                () => { }
            ));
            Components.Add(new TextButton(
                MainGame,
                new Rectangle(20, WorldHeight - (buttonHeight +20) * 2, buttonWidth, buttonHeight),
                buttonFont,
                "Options",
                () => { }
            ));
            Components.Add(new TextButton(
                MainGame,
                new Rectangle(20, WorldHeight - (buttonHeight + 20) * 3, buttonWidth, buttonHeight),
                buttonFont,
                "Multiplayer",
                () => { }
            ));
            Components.Add(new TextButton(
                MainGame,
                new Rectangle(20, WorldHeight - (buttonHeight + 20) * 4, buttonWidth, buttonHeight),
                buttonFont,
                "Play",
                () => { }
            ));

            Components.ForEach(component => component.Initialize());
        }


        public override void Update(GameTime gameTime)
        {
            Components.ForEach(component => component.Update(gameTime));
        }

        public override void Draw(GameTime gameTime)
        {
            Components.ForEach(component => component.Draw(gameTime));
        }

        protected override void UnloadContent()
        {
            Components.ForEach(component => component.Dispose());
            tileTexture.Dispose();

            base.UnloadContent();
        }
    }
}
