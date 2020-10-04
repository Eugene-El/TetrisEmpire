using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace TetrisEmpire.Components
{
    public abstract class AbstractDrawableComponent : DrawableGameComponent
    {
        public MainGame MainGame { get; protected set; }

        public AbstractDrawableComponent(MainGame game) : base(game)
        {
            MainGame = game;
        }

        public int WorldWidth => MainGame.WorldWidth;
        public int WorldHeight => MainGame.WorldHeight;

        public ContentManager Content => MainGame.Content;
        public SpriteBatch SpriteBatch => MainGame.SpriteBatch;
        public Matrix ScaleMatrix => MainGame.ScaleMatrix;
    }
}
