using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using TetrisEmpire.Extensions;

namespace TetrisEmpire.Components.UI
{
    public class TextButton : AbstractDrawableComponent
    {
        public bool Hovered { get; private set; }

        SpriteFont Font { get; set; }
        string Text { get; set; }

        public event EventHandler OnClick;
        public event EventHandler OnHoverBegins;
        public event EventHandler OnHover;
        public event EventHandler OnHoverEnds;

        private RectangleF _rectangle;
        private List<RectangleF> _borders;
        RectangleF Rectangle
        {
            get
            {
                return _rectangle;
            }
            set
            {
                _rectangle = value;
                float side = (Rectangle.Width + Rectangle.Height) / 60,
                    _1_3_height = Rectangle.Height / 3,
                    _2_3_height = value.Height - _1_3_height,
                    _1_3_width = Rectangle.Width / 3,
                    _2_3_width = value.Width - _1_3_width;

                _borders = new List<RectangleF> {
                    new RectangleF(value.X, value.Y + _2_3_height, side, _1_3_height),
                    new RectangleF(value.X, value.Bottom - side, _1_3_width, side),
                    new RectangleF(value.X + _2_3_width, value.Y, _1_3_width, side),
                    new RectangleF(value.Right - side, value.Y, side, _1_3_height)
                };
            }
        }


        public TextButton(MainGame game, RectangleF rectangle, SpriteFont font, string text) : base(game)
        {
            Rectangle = rectangle;
            Font = font;
            Text = text;
        }


        Texture2D borderTexture;
        Texture2D backgroundTexture;

        protected override void LoadContent()
        {
            borderTexture = new Texture2D(GraphicsDevice, 1, 1);
            borderTexture.SetData(new[] { Color.White });
            backgroundTexture = new Texture2D(GraphicsDevice, 1, 1);
            backgroundTexture.SetData(new[] { Color.Gray });

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            var mouseState = Mouse.GetState();
            var wasHovered = Hovered;
            Hovered = Rectangle.Contains(new Vector2(mouseState.X / ScaleMatrix.Right.X, mouseState.Y / ScaleMatrix.Up.Y));
            if (!wasHovered && Hovered)
                OnHoverBegins?.Invoke(this, EventArgs.Empty);
            else if (wasHovered && !Hovered)
                OnHoverEnds?.Invoke(this, EventArgs.Empty);
            else if (Hovered)
            {
                OnHover?.Invoke(this, EventArgs.Empty);
                Cursor.IsActive = true;
            }

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Color textColor = Color.White;
            if (Hovered)
            {
                SpriteBatch.Draw(backgroundTexture, Rectangle.ToApproxRectangle(), Color.White * 0.3f);
                textColor = Color.Black;
            }

            _borders.ForEach(border => SpriteBatch.Draw(borderTexture, border.ToApproxRectangle(), textColor));
            
            SpriteBatch.DrawString(Font, Text, CenterText(Text, Font, Rectangle).Vector, textColor);

            base.Draw(gameTime);
        }
    }
}
