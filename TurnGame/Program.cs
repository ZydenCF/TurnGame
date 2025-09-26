using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnGame
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager game = new GameManager();
            game.Run();

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
