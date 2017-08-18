using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Structures
{
    public class Node
    {
        public Node()
        {

        }

        public Node(int to, int weight)
        {
            this.Vertex = to;
            this.Weight = weight;
        }

        public int Vertex { get; set; }

        public int Weight { get; set; }
    }
}
