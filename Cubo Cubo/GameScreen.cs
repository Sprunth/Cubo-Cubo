using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Cubo_Cubo
{
    class GameScreen : Drawable
    {
        private readonly RenderTexture _targetTex;
        private readonly Sprite _target;

        private GameGrid _grid;

        public GameScreen(Vector2u size, Vector2f pos)
        {
            _targetTex = new RenderTexture(size.X, size.Y) { Smooth = true };
            _target = new Sprite() { Position = pos };

            _grid = new GameGrid(new Vector2u((uint)Math.Floor(size.X/32f), (uint)Math.Floor(size.Y/32f)));

        }


        public void Draw(RenderTarget target, RenderStates states)
        {
            _targetTex.Clear(new Color(20, 20, 20));
            _targetTex.Draw(_grid);
            _targetTex.Display();
            _target.Texture = _targetTex.Texture;

            target.Draw(_target);
        }
    }
}
