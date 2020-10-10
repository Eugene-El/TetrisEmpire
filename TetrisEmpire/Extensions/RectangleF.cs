using Microsoft.Xna.Framework;
using System;
using System.Runtime.Serialization;

namespace TetrisEmpire.Extensions
{
    public struct RectangleF
    {
        [DataMember]
        public float X;
        [DataMember]
        public float Y;
        [DataMember]
        public float Width;
        [DataMember]
        public float Height;

        public RectangleF(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }
        public RectangleF(Vector2 location, Vector2 size)
            : this(location.X, location.Y, size.X, size.Y) { }
        public RectangleF(Rectangle rectangle)
            : this(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height) { }


        public Vector2 Location => new Vector2(X, Y);
        public Vector2 Size => new Vector2(Width, Height);
        public Vector2 Center => new Vector2(X + Width / 2, Y + Height / 2);
        public float Top => Y;
        public float Left => X;
        public float Right => X + Width;
        public float Bottom => Y + Height;


        public bool Contains(float x, float y)
        {
            return x > Left && x < Right
                && y > Top && y < Bottom;
        }
        public bool Contains(Vector2 location) { return Contains(location.X, location.Y); }

        public Rectangle ToApproxRectangle()
        {
            return new Rectangle((int)Math.Round(X), (int)Math.Round(Y), (int)Math.Round(Width), (int)Math.Round(Height));
        }

    }
}
