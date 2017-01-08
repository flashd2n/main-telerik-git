using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timer
{
    class Startup
    {
        static void Main()
        {
            int t = 1 * 1000;
            var myTimer = new Timer(Tasks.Print, t, 10);
            myTimer.ExecuteTimer();

        }
    }
}
