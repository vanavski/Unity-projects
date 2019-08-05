using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAMEOF
{
    public class Mob
    {
        public int x;
        public int y;
        public int type;
        public String symbol;

        public Mob(int type, RandomCoordinates coordinates)
        {
            this.type = type;
            int[] position = coordinates.GetNext();
            x = position[0];
            y = position[1];
            if (type == 0)
            {
                symbol = "$";
                Map.arrayOfMoney.Add(position);
            }
            else
            {
                symbol = "@";
                Map.arrayOfEnemy.Add(position);
            }
        }
    }
}
