using Microsoft.Xna.Framework;

namespace TetrisEmpire.Rooms
{
    public class RoomManager
    {
        protected GameServiceContainer Services;
        public RoomManager(GameServiceContainer services)
        {
            Services = services;
        }

        public AbstractRoom CurrentRoom { get; private set; }

        protected void SetCurrentRoom(AbstractRoom newRoom)
        {
            newRoom.LoadContent();
            CurrentRoom?.UnloadContent();
            CurrentRoom = newRoom;
        }

        public void LoadMainMenu()
        {
            SetCurrentRoom(new MenuRoom(Services));
        }
    }
}
