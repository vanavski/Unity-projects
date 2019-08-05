using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAMEOF
{
    public class RandomCoordinates
    {
        public static List<int[]> coordinates;
        Random random;

        public RandomCoordinates()
        {
            random = new Random();
            coordinates = new List<int[]>();

            for (int i = 1; i < 25; i++)
            {
                for (int j = 1; j < 10; j++)
                {
                    coordinates.Add(new int[] { i, j });
                }
            }
        }

        public int[] GetNext()
        {
            label: int i = random.Next(0, coordinates.Count + 1);
            int[] position;
            if (i != coordinates.Count)
            {
                position = coordinates[i];
                coordinates.RemoveAt(i);
            }
            else goto label;
            return position;

        }
    }
}
