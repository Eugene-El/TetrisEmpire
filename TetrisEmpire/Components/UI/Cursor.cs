using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using TetrisEmpire.Components.Rooms;

namespace TetrisEmpire.Components.UI
{
    public class Cursor : AbstractDrawableComponent
    {
        public bool IsActive { get; set; }
        public bool IsInsideGameWindow { get; private set; }
        public Vector2 Position { get; private set; }
        public Vector2 Size { get; private set; }

        public Cursor(MainGame game, Vector2 size) : base(game)
        {
            Size = size;
        }

        Vector2 offset;
        Vector2 realSize;
        Texture2D cursorTexture;
        Texture2D cursorActiveTexture;

        public override void Initialize()
        {
            Position = new Vector2();
            realSize = new Vector2(20, 24);
            offset = new Vector2(3, 2);
            MainGame.IsMouseVisible = false;
            DrawOrder = int.MaxValue;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            cursorTexture = Content.Load<Texture2D>("images/cursor");
            cursorActiveTexture = Content.Load<Texture2D>("images/cursorActive");

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            IsActive = false;
            var mouseState = Mouse.GetState();
            Position = ToRealSize(mouseState.X, mouseState.Y);
            IsInsideGameWindow = RoomManager.CurrentRoom.Rectangle.Contains(Position);

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            if (IsInsideGameWindow)
                SpriteBatch.Draw(IsActive ? cursorActiveTexture : cursorTexture,
                    new Rectangle((Position - ToRealSize(offset)).ToPoint(), ToRealSize(Size).ToPoint()),
                    Color.White);

            base.Draw(gameTime);
        }

        protected override void UnloadContent()
        {
            cursorTexture.Dispose();
            cursorActiveTexture.Dispose();

            base.UnloadContent();
        }
    }
}
