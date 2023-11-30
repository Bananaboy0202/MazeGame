using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazegame3._0
{
    class Maze : gameobject
    {
        public int CellSizePixels;
        public int MazeSize;
        public Random RNG = new Random();
        public enum CellType
        {
            wall,
            corridor
        }
        public Texture2D wall;
        public Texture2D floor;
        enum direction
        {
            up,
            down,
            left,
            right
        }

        public CellType[,] Grid { get; set; }

        public Maze(int SizeOfMaze, int sizeOfCell)
        {

            Grid = new CellType[SizeOfMaze, SizeOfMaze];
            CellSizePixels = sizeOfCell;
            MazeSize = SizeOfMaze;
            BuildMaze(1, 1);
        }
        public override void LoadContent(ContentManager Content)
        {
            wall = Content.Load<Texture2D>(@"wall");
            floor = Content.Load<Texture2D>(@"floor");
        }

        public void Draw(SpriteBatch sb, GraphicsDeviceManager gd)
        {
            for (int i = 0; i < MazeSize; i++)
            {
                for (int j = 0; j < MazeSize; j++)
                {
                    //Texture2D _texture = new Texture2D(gd.GraphicsDevice, 1, 1); //make a pixel sized texture
                    if (Grid[i, j] == CellType.wall)
                    {
                        sb.Draw(wall, new Vector2(i * CellSizePixels, j * CellSizePixels), Color.Black); //walls are brown squares
                    }
                    else
                    {
                        sb.Draw(floor, new Vector2(i * CellSizePixels, j * CellSizePixels), Color.Gray); //corridors are white squares
                    }
                    //Rectangle position = new Rectangle(i * CellSizePixels, j * CellSizePixels, CellSizePixels, CellSizePixels);
                    //sb.Draw(_texture, position, Color.White);

                }
            }
        }
        //sb.Draw(grids, new Vector2(i* CellSizePixels, j* CellSizePixels), Color.Black); // upload actual tile to be grid to the content box

        private void BuildMaze(int x, int y)
        {
            Grid[x, y] = CellType.corridor;


            {

                List<direction> PossibleDirections = new List<direction>();
                if (y - 2 > 0 && Grid[x, y - 2] == CellType.wall)
                {
                    PossibleDirections.Add(direction.up);
                }
                if (y + 2 < MazeSize - 2 && Grid[x, y + 2] == CellType.wall)
                {
                    PossibleDirections.Add(direction.down);
                }
                if (x - 2 > 0 && Grid[x - 2,y] == CellType.wall)
                {
                    PossibleDirections.Add(direction.left);
                }
                if (x + 2 < MazeSize - 2 && Grid[x + 2,y] == CellType.wall)
                {
                    PossibleDirections.Add(direction.right);
                }
                while (PossibleDirections.Any())
                {
                    //Choose one  possible direction at random
                    int choice = RNG.Next(0, PossibleDirections.Count());
                    direction chosenDirection = PossibleDirections[choice];
                    PossibleDirections.RemoveAt(choice);
                    switch (chosenDirection)
                    {
                        case direction.up:
                            if (Grid[x, y - 2] == CellType.wall)
                            {
                                Grid[x, y - 1] = CellType.corridor;
                                BuildMaze(x, y - 2);
                            }
                            break;
                        case direction.down:
                            if (Grid[x, y + 2] == CellType.wall)
                            {
                                Grid[x, y + 1] = CellType.corridor;
                                BuildMaze(x, y + 2);
                            }
                            break;
                        case direction.left:
                            if (Grid[x - 2, y] == CellType.wall)
                            {
                                Grid[x - 1, y] = CellType.corridor;
                                BuildMaze(x - 2, y);
                            }
                            break;
                        case direction.right:
                            if (Grid[x + 2, y] == CellType.wall)
                            {
                                Grid[x + 1, y] = CellType.corridor;
                                BuildMaze(x + 2, y);
                            }
                            break;
                        default:
                            break;
                    }
                }
                


            }
        }
    }
}