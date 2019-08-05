using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAMEOF
{
    class Game
    {
        public static bool status = true;
        Map map;
        RandomCoordinates coordinates;

        public Game()
        {
            map = new Map(5, 5);
            coordinates = new RandomCoordinates();
        }

        public void Start()
        {
            while (status)
            {
                ConsoleKey key = Console.ReadKey().Key;
                Console.SetCursorPosition(2, 13);
                Console.WriteLine("HP: {0}", Map.hp);
                Console.SetCursorPosition(2, 14);
                Console.WriteLine("MONEY: {0}", Map.value);
                Console.SetCursorPosition(2, 15);
                Console.WriteLine("GAME STATUS: ");
                if (key == ConsoleKey.UpArrow) Up();
                if (key == ConsoleKey.DownArrow) Down();
                if (key == ConsoleKey.RightArrow) Right();
                if (key == ConsoleKey.LeftArrow) Left();
                if (Map.value == 10)
                {
                    status = false;
                    Console.SetCursorPosition(14, 15);
                    Console.WriteLine("YOU WON!!!");
                    Console.ReadKey();
                }
                else if (Map.hp == 0)
                {
                    status = false;
                    Console.SetCursorPosition(14, 15);
                    Console.WriteLine("YOU LOSE!!!");
                    Console.ReadKey();
                }
                else if (RandomCoordinates.coordinates.Count == 0)
                {
                    status = false;
                    Console.SetCursorPosition(14, 15);
                    Console.WriteLine("YOU LOSE!!!YOU DONT HAVE STEPS!");
                    Console.ReadKey();
                }
            }
        }

        public void Up()
        {
            map.Up();
            CreateMob();
        }

        public void Down()
        {
            map.Down();
            CreateMob();
        }

        public void Right()
        {
            map.Right();
            CreateMob();
        }

        public void Left()
        {
            map.Left();
            CreateMob();
        }

        public void CreateMob()
        {
            Random random = new Random();
            Mob mob = new Mob(random.Next(-1, 4), coordinates);
            map.DrawMob(mob);
        }
    }
}
