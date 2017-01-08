using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timer
{
    public delegate void TimerDelegate();

    public class Timer
    {
        private int interval;
        private int numberOfExecutions;
        private TimerDelegate timerAction;

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
        public TimerDelegate TimerAction
        {
            get
            {
                return this.timerAction;
            }
            set
            {
                this.timerAction = value;
            }
        }

        public Timer(TimerDelegate action, int interval, int numberOfExecutions)
        {
            this.TimerAction = action;
            this.Interval = interval;
            this.NumberOfExecutions = numberOfExecutions;
        }

        public void ExecuteTimer()
        {
            for (int i = 0; i < this.NumberOfExecutions; i++)
            {
                this.TimerAction();
                Thread.Sleep(Interval);
            }
        }
    }
}