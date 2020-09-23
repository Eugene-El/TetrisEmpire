using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace TetrisEmpire.Rooms
{
    public abstract class AbstractRoom
    {
        protected ContentManager Content;
        protected GameServiceContainer Services;
        public AbstractRoom(GameServiceContainer services)
        {
            Services = services;
            Content = new ContentManager(services, "Content");
        }
        
        public abstract void LoadContent();
        public abstract void Update(GameTime gameTime);
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
        public virtual void UnloadContent()
        {
            if (Content != null)
                Content.Unload();
        }
    }
}
