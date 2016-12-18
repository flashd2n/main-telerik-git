using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redoSeven.folderTwo
{
    class Sequence
    {
        private static int currentValue = 0;

        public static int NextValue()
        {
            currentValue++;
            return currentValue;
        }
    }
}
