using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using TetrisEmpire.Components.UI;
using TetrisEmpire.Extensions;

namespace TetrisEmpire.Components.Rooms
{
    public class MenuRoom : AbstractRoom
    {
        private Texture2D tileTexture;
        private Texture2D background;

        private SpriteFont buttonFont;
        private SpriteFont headerFont;

        private Color backgroundCurrentColor;
        private Color backgroundDestinationColor;

        private float buttonWidth;
        private float buttonHeight;

        private Vector2 headerPostition1;
        private Vector2 headerPostition2;

        private List<AbstractDrawableComponent> components;


        public MenuRoom(MainGame game) : base(game) { }

        public override void Initialize()
        {
            components = new List<AbstractDrawableComponent>();
            backgroundCurrentColor = backgroundDestinationColor = Color.DarkBlue;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            tileTexture = Content.Load<Texture2D>("images/tetrisTile");
            background = Content.Load<Texture2D>("images/background");
            buttonFont = Content.Load<SpriteFont>("fonts/button");
            headerFont = Content.Load<SpriteFont>("fonts/bigHeader");

            InitButtons();

            RectangleF headerRect;
            (headerPostition1, headerRect) = CenterText("Tetris", headerFont, new RectangleF(20, 20,  buttonWidth, WorldHeight / 5));
            headerPostition2 = CenterText("Empire", headerFont, new RectangleF(0, headerRect.Bottom, buttonWidth + 20 * 2, headerRect.Height)).Vector;

            components.ForEach(component => component.Initialize());

            base.LoadContent();
        }


        public override void Update(GameTime gameTime)
        {
            components.ForEach(component => component.Update(gameTime));
            backgroundCurrentColor = Color.Lerp(backgroundCurrentColor, backgroundDestinationColor, (float)gameTime.ElapsedGameTime.TotalSeconds);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            SpriteBatch.Draw(background, Rectangle, backgroundCurrentColor);
            components.ForEach(component => component.Draw(gameTime));

            SpriteBatch.DrawString(headerFont, "Tetris", headerPostition1, Color.White);
            SpriteBatch.DrawString(headerFont, "Empire", headerPostition2, Color.White);

            base.Update(gameTime);
        }

        protected override void UnloadContent()
        {
            components.ForEach(component => component.Dispose());
            tileTexture.Dispose();

            base.UnloadContent();
        }


        private EventHandler GetChangeColorFunction(Color color)
        {
            return (_, __) =>
            {
                backgroundDestinationColor = color;
            };
        }
        private void InitButtons()
        {
            buttonWidth = WorldWidth / 3f;
            buttonHeight = buttonWidth / 5f;

            TextButton exitBtn = new TextButton(
                MainGame,
                new RectangleF(20, WorldHeight - (20 + buttonHeight), buttonWidth, buttonHeight),
                buttonFont,
                "Exit"
            );
            exitBtn.OnHoverBegins += GetChangeColorFunction(Color.Red);
            TextButton optionsBtn = new TextButton(
                MainGame,
                new RectangleF(20, WorldHeight - (buttonHeight + 20) * 2, buttonWidth, buttonHeight),
                buttonFont,
                "Options"
            );
            optionsBtn.OnHoverBegins += GetChangeColorFunction(Color.Yellow);
            TextButton multiplayerBtn = new TextButton(
                MainGame,
                new RectangleF(20, WorldHeight - (buttonHeight + 20) * 3, buttonWidth, buttonHeight),
                buttonFont,
                "Multiplayer"
            );
            multiplayerBtn.OnHoverBegins += GetChangeColorFunction(Color.Magenta);
            TextButton playBtn = new TextButton(
                MainGame,
                new RectangleF(20, WorldHeight - (buttonHeight + 20) * 4, buttonWidth, buttonHeight),
                buttonFont,
                "Play"
            );
            playBtn.OnHoverBegins += GetChangeColorFunction(Color.Lime);
            components.AddRange(new List<TextButton>
            {
                exitBtn, optionsBtn, multiplayerBtn, playBtn
            });
        }
    }
}
