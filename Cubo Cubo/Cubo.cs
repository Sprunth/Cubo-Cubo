using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Cubo_Cubo
{
    class Cubo : Drawable
    {
        private readonly Sprite _baseSpr, _borderSpr;
        private CuboType cuboType;

        private readonly Dictionary<CuboType, Texture> cuboTextures;
        private readonly Dictionary<CuboType, Color> cuboColors; 

        public CuboType CuboType
        {
            get { return cuboType; }
            set { cuboType = value; SetTexture(value); }
        }

        private readonly Dictionary<BorderSide, Sprite> _borders;
        private readonly Texture _borderFullTex, _borderConnectTex;

        // TODO: sprite border

        public Cubo(Vector2f pos)
        {
            _baseSpr = new Sprite() { Position = pos };

            cuboTextures = new Dictionary<CuboType, Texture>()
            {
                {CuboType.Empty, new Texture(@"Graphics/Empty.png")},
                {CuboType.Blue, new Texture(@"Graphics/Color.png")},
                {CuboType.Green, new Texture(@"Graphics/Color.png")},
                {CuboType.Red, new Texture(@"Graphics/Color.png")},
                {CuboType.Yellow, new Texture(@"Graphics/Color.png")},
            };
            cuboColors = new Dictionary<CuboType, Color>()
            {
                {CuboType.Empty, new Color(255, 255, 255)},
                {CuboType.Blue, new Color(29, 111, 211)},
                {CuboType.Green, new Color(48, 211, 40)},
                {CuboType.Red, new Color(204, 18, 36)},
                {CuboType.Yellow, new Color(239, 236, 28)},
            };

            _borders = new Dictionary<BorderSide, Sprite>()
            {
                {BorderSide.Top, new Sprite() {Position = pos + new Vector2f(1,0)}},
                {BorderSide.Right, new Sprite() {Position = pos + new Vector2f(32, 0), Rotation = 90}},
                {BorderSide.Left, new Sprite() {Position = pos + new Vector2f(1,0), Rotation = 90}},
                {BorderSide.Bottom, new Sprite() { Position = pos + new Vector2f(0, 31)}},
            };
            _borderFullTex = new Texture(@"Graphics/Border_full.png");
            _borderConnectTex = new Texture(@"Graphics/Border_connect.png");
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(_baseSpr);
            foreach (var border in _borders)
            {
                target.Draw(border.Value);
            }
        }

        void SetTexture(CuboType ct)
        {
            _baseSpr.Texture = cuboTextures[ct];
            _baseSpr.Color = cuboColors[ct];
        }

        public void SetBorder(BorderSide side, bool full)
        {
            _borders[side].Texture = full ? _borderFullTex : _borderConnectTex;
        }
    }

    public enum CuboType { Empty, Green, Blue, Yellow, Red }
    public enum BorderSide { Top, Bottom, Left, Right }
}
