using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAMEOF
{
    class Map
    {
        int x;
        int y;

        public static List<int[]> arrayOfEnemy = new List<int[]>();
        public static List<int[]> arrayOfMoney = new List<int[]>();

        public static int value = 0;
        public static int hp = 2;

        public Map(int startX, int startY)
        {
            this.x = startX;
            this.y = startY;

            DrawBorder();
            DrawHero(startX, startY);
        }

        public static void DrawHero(int x, int y)
        {
            int coordX = x;
            int coordY = y;
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("0");
        }

        public void DrawMob(Mob mob)
        {
            if (mob.type == 0) Console.ForegroundColor = ConsoleColor.Green;
            else Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(mob.x, mob.y);
            Console.Write(mob.symbol);
            Console.ResetColor();
        }

        private void Clear(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ");
        }

        public void Up()
        {
            GetIntersectionOfEnemy(0, -1, x, y);
            GetIntersectionOfMoney(0, -1, x, y);
            Clear(x, y);
            if (y > 1) y--;
            DrawHero(x, y);
        }

        public void Down()
        {
            GetIntersectionOfEnemy(0, 1, x, y);
            GetIntersectionOfMoney(0, 1, x, y);
            Clear(x, y);
            if (y < 9) y++;
            DrawHero(x, y);
        }

        public void Right()
        {
            GetIntersectionOfEnemy(1, 0, x, y);
            GetIntersectionOfMoney(1, 0, x, y);
            Clear(x, y);
            if (x < 24) x++;
            DrawHero(x, y);
        }

        public void Left()
        {
            GetIntersectionOfEnemy(-1, 0, x, y);
            GetIntersectionOfMoney(-1, 0, x, y);
            Clear(x, y);
            if (x > 1) x--;
            DrawHero(x, y);
        }
        public void GetIntersectionOfEnemy(int a, int b, int x, int y)
        {
            for (int i = 0; i < arrayOfEnemy.Count; i++)
                if (x + a == arrayOfEnemy[i][0] && y + b == arrayOfEnemy[i][1])
                {
                    hp--;
                    arrayOfEnemy.RemoveAt(i);
                }
        }
        public void GetIntersectionOfMoney(int a, int b, int x, int y)
        {
            for (int i = 0; i < arrayOfMoney.Count; i++)
                if (x + a == arrayOfMoney[i][0] && y + b == arrayOfMoney[i][1])
                {
                    value++;
                    arrayOfMoney.RemoveAt(i);
                }
        }

        private void DrawBorder()
        {
            for (int x = 0; x < 27; x++)
            {
                Console.SetCursorPosition(x, 0);
                Console.WriteLine('#');
                Console.SetCursorPosition(x, 10);
                Console.Write("#");
            }
            for (int y = 0; y < 11; y++)
            {
                Console.SetCursorPosition(0, y);
                Console.WriteLine('#');
                Console.SetCursorPosition(26, y);
                Console.Write("#");
            }
        }
    }
}
