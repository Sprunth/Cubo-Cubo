using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML;
using SFML.Audio;
using SFML.Graphics;
using SFML.Window;

namespace Cubo_Cubo
{
    class Game
    {
        private readonly RenderWindow _window;

        private readonly RenderTexture _targetTex;
        private readonly Sprite _target;

        private GameScreen gameScreen;

        public readonly Random Rand;

        public Game()
        {
            Rand = new Random();

            _window = new RenderWindow(new VideoMode(700, 900), "Cubo Cubo", Styles.Default, new ContextSettings() { AntialiasingLevel = 4});
            _targetTex = new RenderTexture(_window.Size.X, _window.Size.Y) { Smooth = true };
            _target = new Sprite();

            _window.Closed += _window_Closed;
        }

        public void Initialize()
        {
            gameScreen = new GameScreen(new Vector2u(320, 800), new Vector2f(20, 50));
        }

        public void Run()
        {
            while (_window.IsOpen())
            {
                Update();
                Draw();
            }
        }

        void Update()
        {
            _window.DispatchEvents();
        }

        void Draw()
        {
            _targetTex.Clear(new Color(80,80,80));
            _targetTex.Draw(gameScreen);
            
            _targetTex.Display();
            _target.Texture = _targetTex.Texture;

            _window.Clear();
            _window.Draw(_target);
            _window.Display();
        }

        #region Window Events

        void _window_Closed(object sender, EventArgs e)
        {
            _window.Close();
        }

        #endregion
    }
}
