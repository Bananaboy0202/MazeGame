using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace mazegame3._0
{
    class MainCharacter : gameobject
    {
        public enum Direction
        {
            up,
            right,
            down,
            left,

        }
        private Vector2 heromovement;
        private float heroFrameTime = 100;
        private int heroframe = 0;
        private Direction heroDirection = Direction.down;
        private float timeExpired;

        public MainCharacter()
        {
            location = new Vector2(100, 100);
            heromovement = new Vector2(0, 0);
        }
        public override void LoadContent(ContentManager Content)
        {
            texture = Content.Load<Texture2D>(@"spritehero4");
        }
        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.A))
            {
                heromovement.X = -1;
                heromovement.Y = 0;
                heroDirection = Direction.left;
            }
            if (ks.IsKeyDown(Keys.D))
            {
                heromovement.X = 1;
                heromovement.Y = 0;
                heroDirection = Direction.right;
            }
            if (ks.IsKeyDown(Keys.W))
            {
                heromovement.X = 0;
                heromovement.Y = -1;
                heroDirection = Direction.up;
            }
            if (ks.IsKeyDown(Keys.S))
            {
                heromovement.X = 0;
                heromovement.Y = 1;
                heroDirection = Direction.down;
            }

            location = location + heromovement;


            timeExpired += gameTime.ElapsedGameTime.Milliseconds;

            if (timeExpired > heroFrameTime)
            {
                heroframe = (heroframe + 1) % 3;
                timeExpired = 0;
            }


        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            int x = heroframe * 50;
            int y = ((int)heroDirection * 65);
            spriteBatch.Draw(texture, location, new Rectangle(x, y, 50, 65), Color.White);
        }
    }
}
