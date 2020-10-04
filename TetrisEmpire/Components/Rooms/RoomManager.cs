using Microsoft.Xna.Framework;

namespace TetrisEmpire.Components.Rooms
{
    public class RoomManager : AbstractDrawableComponent
    {

        public RoomManager(MainGame game) : base(game) { }

        public AbstractRoom CurrentRoom { get; private set; }

        protected void SetCurrentRoom(AbstractRoom newRoom)
        {
            newRoom?.Initialize();
            CurrentRoom?.Dispose();
            CurrentRoom = newRoom;
        }

        public void LoadMainMenu()
        {
            SetCurrentRoom(new MenuRoom(MainGame));
        }

        public override void Update(GameTime gameTime)
        {
            CurrentRoom?.Update(gameTime);
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            CurrentRoom?.Draw(gameTime);
            base.Draw(gameTime);
        }

    }
}
