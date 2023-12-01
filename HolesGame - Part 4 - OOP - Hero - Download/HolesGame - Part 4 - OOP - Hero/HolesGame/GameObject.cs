using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace HolesGame
{
    class GameObject
    {
        public Vector2 Location; //public anyone can see it!
        protected Texture2D Texture;

        public virtual void LoadContent(ContentManager Content)
        {
        }
        
        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Location, Color.White);
        }
    }

}
