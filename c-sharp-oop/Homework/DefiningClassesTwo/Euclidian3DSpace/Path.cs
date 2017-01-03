using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euclidian3DSpace
{
    public class Path
    {
        private List<Point3D> sequencePoints = new List<Point3D>();

        public Path()
        {
        }

        public void AddPoint(Point3D point)
        {
            this.sequencePoints.Add(point);
        }

        public List<Point3D> SequencePoints
        {
            get { return this.sequencePoints; }
        }

        public void PrintAllSequences()
        {
            foreach (var item in this.SequencePoints)
            {
                Console.WriteLine(item);
            }


        }
    }
}
