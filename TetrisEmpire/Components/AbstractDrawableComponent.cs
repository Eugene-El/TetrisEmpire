using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TetrisEmpire.Components.Rooms;
using TetrisEmpire.Components.UI;
using TetrisEmpire.Extensions;

namespace TetrisEmpire.Components
{
    public abstract class AbstractDrawableComponent : DrawableGameComponent
    {
        protected MainGame MainGame { get; private set; }

        public AbstractDrawableComponent(MainGame game) : base(game)
        {
            MainGame = game;
        }

        protected int WorldWidth => MainGame.WorldWidth;
        protected int WorldHeight => MainGame.WorldHeight;

        protected ContentManager Content => MainGame.Content;
        protected SpriteBatch SpriteBatch => MainGame.SpriteBatch;
        protected RoomManager RoomManager => MainGame.RoomManager;
        protected Matrix ScaleMatrix => MainGame.ScaleMatrix;
        protected Cursor Cursor => MainGame.Cursor;


        protected Vector2 ToRealSize(Vector2 vector) => ToRealSize(vector.X, vector.Y);
        protected Vector2 ToRealSize(float x, float y)
        {
            return new Vector2(x / ScaleMatrix.Right.X, y / ScaleMatrix.Up.Y);
        }

        protected (Vector2 Vector, RectangleF Rectangle) CenterText(string text, SpriteFont font, RectangleF rectangle)
        {
            var textMeasure = font.MeasureString(text);
            var resultVector = rectangle.Center - textMeasure / 2f;
            var resultRectangle = new RectangleF(resultVector, textMeasure);
            return (resultVector, resultRectangle);
        }
    }
}
