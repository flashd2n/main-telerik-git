using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euclidian3DSpace
{
    class Startup
    {
        static void Main()
        {
            Path path = new Path();

            path.AddPoint(new Point3D(1, 2, 3));
            path.AddPoint(new Point3D(6, -6, 1));
            path.AddPoint(new Point3D(1, 2, 3));
            path.AddPoint(new Point3D(5, -4, 4));
            path.AddPoint(new Point3D(8, 8, 8));
            path.AddPoint(new Point3D(-8, -8, -8));
            path.AddPoint(new Point3D(1, 1, 3));
            path.AddPoint(new Point3D(-1, 7, -3));
            path.AddPoint(new Point3D(13, 5, 3));
            path.AddPoint(new Point3D(-1, -12, -6));

            PathStorage.SavePath(path);

            Path loaded = PathStorage.LoadPath("path.txt");

            loaded.PrintAllSequences();
        }
    }
}
