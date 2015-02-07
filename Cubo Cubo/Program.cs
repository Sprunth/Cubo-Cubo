using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cubo_Cubo
{
    class Program
    {
        public static Game ActiveGame { get; private set; }

        static void Main(string[] args)
        {
            ActiveGame = new Game();
            ActiveGame.Initialize();
            ActiveGame.Run();
        }
    }
}
