using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace TetrisEmpire.Components.Rooms
{
    public abstract class AbstractRoom : AbstractDrawableComponent
    {
        public AbstractRoom(MainGame game) : base(game) { }

        public Rectangle Rectangle => new Rectangle(0, 0, WorldWidth, WorldHeight);

    }
}
