using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using TetrisEmpire.Components.Rooms;
using TetrisEmpire.Components.UI;

namespace TetrisEmpire
{
    public class MainGame : Game
    {
        public const int WorldWidth = 1920;
        public const int WorldHeight = 1080;

        public GraphicsDeviceManager GraphicsDeviceManager { get; private set; }
        public SpriteBatch SpriteBatch { get; private set; }
        public RoomManager RoomManager { get; private set; }
        public Matrix ScaleMatrix { get; private set; }
        public Cursor Cursor { get; private set; }

        public MainGame()
        {
            GraphicsDeviceManager = new GraphicsDeviceManager(this);
            RoomManager = new RoomManager(this);
            Cursor = new Cursor(this, new Vector2(20, 23));

            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Window.ClientSizeChanged += OnResize;
            Window.AllowUserResizing = true;
            OnResize(this, new EventArgs());

            SpriteBatch = new SpriteBatch(GraphicsDevice);
            Components.Add(Cursor);
            Components.Add(RoomManager);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            RoomManager.LoadMainMenu();

            base.LoadContent();
        }

        private bool wasFullscreenChanged = false;
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.F11))
            {
                if (!wasFullscreenChanged)
                {
                    GraphicsDeviceManager.ToggleFullScreen();
                    wasFullscreenChanged = true;
                }
            }
            else
            {
                wasFullscreenChanged = false;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            SpriteBatch.Begin(SpriteSortMode.Deferred, transformMatrix: ScaleMatrix);
            base.Draw(gameTime);
            SpriteBatch.End();
        }

        protected void OnResize(Object sender, EventArgs e)
        {
            Window.ClientSizeChanged -= OnResize;

            GraphicsDeviceManager.PreferredBackBufferWidth = Window.ClientBounds.Width;
            GraphicsDeviceManager.PreferredBackBufferHeight = Window.ClientBounds.Height;
            
            GraphicsDeviceManager.ApplyChanges();
            Window.ClientSizeChanged += OnResize;

            float scaleX = (float)Window.ClientBounds.Width / WorldWidth;
            float scaleY = (float)Window.ClientBounds.Height / WorldHeight;
            ScaleMatrix = Matrix.CreateScale(new Vector3(scaleX, scaleY, 1));
        }
    }
}
