using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace TetrisEmpire.Components.UI
{
    public class TextButton : AbstractDrawableComponent
    {
        public bool Hovered { get; private set; }

        SpriteFont Font { get; set; }
        string Text { get; set; }
        Action OnClick { get; set; }

        private Rectangle _rectangle;
        private List<Rectangle> _borders;
        Rectangle Rectangle
        {
            get
            {
                return _rectangle;
            }
            set
            {
                _rectangle = value;
                int side = (Rectangle.Width + Rectangle.Height) / 60,
                    _1_3_height = Rectangle.Height / 3,
                    _2_3_height = value.Height - _1_3_height,
                    _1_3_width = Rectangle.Width / 3,
                    _2_3_width = value.Width - _1_3_width;

                _borders = new List<Rectangle> {
                    new Rectangle(value.X, value.Y + _2_3_height, side, _1_3_height),
                    new Rectangle(value.X, value.Y + value.Height - side, _1_3_width, side),
                    new Rectangle(value.X + _2_3_width, value.Y, _1_3_width, side),
                    new Rectangle(value.X + value.Width - side, value.Y, side, _1_3_height)
                };
            }
        }


        public TextButton(MainGame game, Rectangle rectangle, SpriteFont font, string text, Action onClick) : base(game)
        {
            Rectangle = rectangle;
            Font = font;
            Text = text;
            OnClick = onClick;
        }


        Texture2D borderTexture;
        Texture2D backgroundTexture;

        protected override void LoadContent()
        {
            borderTexture = new Texture2D(GraphicsDevice, 1, 1);
            borderTexture.SetData(new[] { Color.White });
            backgroundTexture = new Texture2D(GraphicsDevice, 1, 1);
            backgroundTexture.SetData(new[] { Color.DarkGray });

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
            Hovered = Rectangle.Contains(new Vector2(mouseState.X / ScaleMatrix.Right.X, mouseState.Y / ScaleMatrix.Up.Y));

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Color textColor = Color.White;
            if (Hovered)
            {
                SpriteBatch.Draw(backgroundTexture, Rectangle, Color.White);
                textColor = Color.Black;
            }

            _borders.ForEach(border => SpriteBatch.Draw(borderTexture, border, textColor));
            var textPosition = Rectangle.Center.ToVector2() - Font.MeasureString(Text) / 2f;
            SpriteBatch.DrawString(Font, Text, textPosition, textColor);

            base.Draw(gameTime);
        }
    }
}
