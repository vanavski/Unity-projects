using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAMEOF
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(75, 25);
            Console.CursorVisible = false;
            CreateMenu textMenu = new CreateMenu();
            textMenu.TextMenu2();
            Game game = new Game();
            game.Start();
        }
    }
}
