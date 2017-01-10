using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TimerEvents
{
    public delegate void EventHandlerTimer(object sender, MyTimerArgs arg);

    class Timer
    {
        private int interval;
        private int numberOfExecutions;
        public event EventHandlerTimer timerEvent;

        public int Interval
        {
            get
            {
                return this.interval;
            }
            set
            {
                this.interval = value;
            }
        }
        public int NumberOfExecutions
        {
            get
            {
                return this.numberOfExecutions;
            }
            set
            {
                this.numberOfExecutions = value;
            }
        }

        public Timer(int interval, int numberOfExecutions)
        {
            this.Interval = interval;
            this.NumberOfExecutions = numberOfExecutions;
        }

        public void TriggerTimer()
        {
            for (int i = 0; i < this.NumberOfExecutions; i++)
            {
                Thread.Sleep(this.Interval);
                this.timerEvent(this, new MyTimerArgs { Something = "somthing"});
            }
        }
    }

    public class MyTimerArgs : EventArgs
    {
        public string Something { get; set; }
    }

}
