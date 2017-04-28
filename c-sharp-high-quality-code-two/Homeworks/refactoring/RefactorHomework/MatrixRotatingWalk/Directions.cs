namespace MatrixRotatingWalk
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public enum Directions
    {
        SouthEast,      // 1 1
        South,          // 1 0
        SouthWest,      // 1 -1
        West,           // 0 -1
        NorthWest,      // -1 -1
        North,          // -1 0
        NorthEast,      // -1 1
        East            // 0 1
    }
}