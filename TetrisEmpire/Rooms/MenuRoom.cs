using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TetrisEmpire.Rooms
{
    public class MenuRoom : AbstractRoom
    {
        private Texture2D tileTexture;

        public MenuRoom(GameServiceContainer services) : base(services) { }

        public override void LoadContent()
        {
            tileTexture = Content.Load<Texture2D>("images/tetrisTile");
        }

        public override void Update(GameTime gameTime)
        {
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tileTexture, new Rectangle(10, 10, 150, 150), Color.Red);
            spriteBatch.Draw(tileTexture, new Rectangle(170, 10, 150, 150), Color.Blue);
            spriteBatch.Draw(tileTexture, new Rectangle(330, 10, 150, 150), Color.Green);
            spriteBatch.End();
        }
    }
}
