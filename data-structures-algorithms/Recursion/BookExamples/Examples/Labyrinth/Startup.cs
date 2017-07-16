using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    public class Startup
    {
        static void Main()
        {
            var lab = new char[,]
            {
 {' ','*',' ',' ',' ',' ','*',' ',' ',' ',' ','*','*',' ',' '},
 {' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
 {' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' '},
 {' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' '},
 {' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' '},
 {' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' '},
 {' ','*','*','*',' ','*',' ',' ',' ',' ',' ','*','*','*','*'},
 {' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ','*','*',' ',' '},
 {' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ','*','e'},
};

            var visited = new bool[lab.GetLength(0), lab.GetLength(1)];

            GetPath(0, 0, lab, visited, "Found the end at: ", "");

        }

        public static void GetPath(int x, int y, char[,] lab, bool[,] visited, string output, string direction)
        {
            if (x < 0 || x >= lab.GetLength(0))
            {
                return;
            }

            if (y < 0 || y >= lab.GetLength(1))
            {
                return;
            }

            var position = lab[x, y];

            if (position == 'e')
            {
                output += direction;
                Console.WriteLine(output);
                return;
            }

            if (position == '*' || visited[x, y] == true)
            {
                return;
            }

            
            visited[x, y] = true;
            output += direction;
            Console.WriteLine($"{x} {y}");


            GetPath(x , y - 1, lab, visited, output, "L"); // left
            GetPath(x - 1, y, lab, visited, output, "U"); // up
            GetPath(x, y + 1, lab, visited, output, "R"); // right
            GetPath(x + 1, y, lab, visited, output, "D"); // down

            //visited[x, y] = false;
            //output = output.Remove(output.Length - 1);
        }
    }
}
