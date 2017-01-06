using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Timer
{
    class Startup
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer(Timer.Print, 4, 2000);
            timer.TimerExecute();
        }
    }
}