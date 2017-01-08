using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerEvents
{
    class Startup
    {
        static void Main()
        {
            int t = 1 * 1000;
            int executions = 10;
            var myTimer = new Timer(t, executions);

            //myTimer.timerEvent += ExecuteTask;
            myTimer.timerEvent += () => Console.WriteLine("Hey There!");

            myTimer.TriggerTimer();

        }

        private static void ExecuteTask()
        {
            Console.WriteLine("Hey There!");
        }
    }
}
