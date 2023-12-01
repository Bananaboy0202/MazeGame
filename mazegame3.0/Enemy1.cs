using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Threading;

namespace mazegame3._0
{
    class Enemy1 : gameobject
    {
        public enum Directions
        {
            down,
            left,
            right,
            up,
        
        }
        //private Vector2 monster1movement;
        //private float monster1FrameTime = 100;
        //private int monster1frame = 0;
        private Directions monster1Direction = Directions.down;
        //private float timeExpired;

        public Enemy1()
        {
            location = new Vector2(300, 100);
            movement = new Vector2(0, 0);
        }
        public override void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>(@"Enemy1.2");
            Edge = new Rectangle((int)location.X, (int)location.Y, texture.Width, texture.Height);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            Random randomdirection = new Random();
            //Thread.Sleep(5000);
            //int actualran = randomdirection.Next(1, 4);

            //if (actualran == 1)
            //{
            //    movement.X = -1;
            //    movement.Y = 0;
            //    monster1Direction = Directions.left;

            //    //actualran = randomdirection.Next(1, 4);
            //}
            //if (actualran == 2)
            //{
            //    movement.X = 1;
            //    movement.Y = 0;
            //    monster1Direction = Directions.right;
            //    //Thread.Sleep(5000);
            //    //actualran = randomdirection.Next(1, 4);
            //}
            //if (actualran == 3)
            //{
            //    movement.X = 0;
            //    movement.Y = -1;
            //    monster1Direction = Directions.up;
            //    //Thread.Sleep(5000);
            //    //actualran = randomdirection.Next(1, 4);
            //}
            //if (actualran == 4)
            //{
            //    movement.X = 0;
            //    movement.Y = -1;
            //    monster1Direction = Directions.up;
            //    //Thread.Sleep(5000);
            //    //actualran = randomdirection.Next(1, 4);
            //}

            location = location + movement;


            timeExpired += gameTime.ElapsedGameTime.Milliseconds;

            if (timeExpired > FrameTime)
            {
                frame = (frame + 1) % 3;
                timeExpired = 0;
            }


        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            int x = frame * 53;
            int y = ((int)monster1Direction * 57);
            spriteBatch.Draw(texture, location, new Rectangle(x, y, 53, 55), Color.White);
        }


    }
}
