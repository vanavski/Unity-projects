using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAMEOF
{
    class CreateMenu
    {
        public bool check = true;
        public int Height { get; } = Console.LargestWindowHeight;
        public int Width { get; } = Console.WindowWidth;
        public CreateMenu() { }
        public void TextMenu2()
        {            
            Start();
            while (Game.status)
                TouchReaction();
        }
        public void Start()
        {
            Coursor();
            CreatMenu();
        }
        public void Coursor()
        {
            Console.SetCursorPosition(30, 10);
            Console.Write("*");
        }
        public void CoursorGoUp()
        {
            Console.SetCursorPosition(30, 20);
            Console.Write(" ");
            Console.SetCursorPosition(30, 10);
            Console.Write("*");
        }
        public void CoursorGoDown()
        {
            Console.SetCursorPosition(30, 10);
            Console.Write(" ");
            Console.SetCursorPosition(30, 20);
            Console.Write("*");
        }
        public void CreatMenu(string name1 = "Поехали!", string name2 = "Информация об игре")
        {
            Console.SetCursorPosition(32, 10);
            Console.Write(name1);
            Console.SetCursorPosition(32, 20);
            Console.Write(name2);
        }
        public void TouchReaction()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.UpArrow:
                    check = true;
                    CoursorGoUp();
                    break;
                case ConsoleKey.DownArrow:
                    check = false;
                    CoursorGoDown();
                    break;
                case ConsoleKey.Enter:
                    if (check)
                    {
                        Console.Clear();
                        Game move = new Game();
                        move.Start();
                    }
                    else
                    {
                        Console.Clear();
                        using (StreamReader sr = new StreamReader("input.txt"))
                        {
                            string line = sr.ReadToEnd();
                            Console.WriteLine(line);
                            while (true)
                                switch (Console.ReadKey(true).Key)
                                {
                                    case ConsoleKey.Escape:
                                        Console.Clear();
                                        check = true;
                                        TextMenu2();
                                        break;
                                }
                        }
                    }
                    break;
            }
        }
    }
}