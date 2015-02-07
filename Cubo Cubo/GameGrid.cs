using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Cubo_Cubo
{
    class GameGrid : Drawable
    {
        private Cubo[,] _grid;

        public GameGrid(Vector2u gridSize)
        {
            _grid = new Cubo[gridSize.X, gridSize.Y];

            for (var x = 0; x < gridSize.X; x++)
            {
                for (var y = 0; y < gridSize.Y; y++)
                {
                    _grid[x,y] = new Cubo(new Vector2f(x*32,y*32)) { CuboType = CuboType.Blue };
                    _grid[x, y].SetBorder(BorderSide.Top, Program.ActiveGame.Rand.NextDouble() > 0.5);
                    _grid[x, y].SetBorder(BorderSide.Left, Program.ActiveGame.Rand.NextDouble() > 0.5);
                    _grid[x, y].SetBorder(BorderSide.Right, Program.ActiveGame.Rand.NextDouble() > 0.5);
                    _grid[x, y].SetBorder(BorderSide.Bottom, Program.ActiveGame.Rand.NextDouble() > 0.5);
                }
            }
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            foreach (var cubo in _grid)
            {
                target.Draw(cubo);
            }
        }
    }
}
