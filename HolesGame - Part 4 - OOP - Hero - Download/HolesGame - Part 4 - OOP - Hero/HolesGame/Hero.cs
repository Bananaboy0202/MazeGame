using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace HolesGame
{
    class Hero : GameObject
    {
        //attributes
        public enum Direction
        {
            down,
            left,
            right,
            up,
        }
        private Vector2 Movement; //direction of travel.
        private float FrameTime = 100; //how many millioseconds per animation frame
        private int Frame = 0; //frame count : goes 0,1,2,3,0,1,2,3.....
        private Direction direction = Direction.down; //direction of travel
        private float timeExpired; //how much time has elapsed since last update
  
        public Hero()
            {
            // constructor
            Location = new Vector2(100, 100);
            Movement = new Vector2(0, 0);
            }

        public override void LoadContent(Microsoft.Xna.Framework.Content.ContentManager Content)
            {
            Texture = Content.Load<Texture2D>(@"SpriteMapHero");
            }

        public override void Update(GameTime gameTime)
            {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.A))
                {
                Movement.X = -1;
                Movement.Y = 0;
                direction = Direction.left;
                }
         if (ks.IsKeyDown(Keys.D))
                {
                Movement.X = 1;
                Movement.Y = 0;
                direction = Direction.right;
                }
         if (ks.IsKeyDown(Keys.S))
                {
                Movement.X = 0;
                Movement.Y = 0;
                direction = Direction.down;
                }
         if (ks.IsKeyDown(Keys.W))
                {
                Movement.X = 0;
                Movement.Y = -1;
                direction = Direction.up;
                }
         if (ks.IsKeyDown(Keys.X))
                {
                Movement.X = 0;
                Movement.Y = 1;
                direction = Direction.down;
                }

         Location = Location + Movement;

         timeExpired += gameTime.ElapsedGameTime.Milliseconds;
        
         //is it time to change the hero animation frame?
         if (timeExpired > FrameTime)
         {
             Frame = (Frame + 1) % 4; //increase frame count by 1 and wrap round
             timeExpired = 0;
         }
     }
        public override void Draw(SpriteBatch spriteBatch)
        {
            // workout which sprite from the sprite map to choose
            // all sprites are 32*54 in size.
            // there are fur animation frames per direction.
            int X = Frame * 32;
            int Y = ((int)direction * 54);
            spriteBatch.Draw(Texture, Location, new Rectangle(X, Y, 32, 54), Color.White);
        }

}

}
