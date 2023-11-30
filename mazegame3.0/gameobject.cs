using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;



namespace mazegame3._0
{
    class gameobject
    {
        public Vector2 location;
        protected Texture2D texture;
        public Vector2 movement;
        public float FrameTime = 100;
        public int frame = 0;
        
        public float timeExpired;
        public virtual void LoadContent(ContentManager Content)
        {

        }
        public virtual void Update(GameTime gameTime)
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, location, Color.White);
        }


    }
}
