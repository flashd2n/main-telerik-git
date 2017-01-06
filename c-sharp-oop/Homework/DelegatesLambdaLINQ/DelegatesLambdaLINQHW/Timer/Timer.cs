using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Timer
{
    // Declare delegate
    public delegate void SampleDelegate();

    public class Timer
    {
        // Fields
        private int timesOfExecute;
        private int intervalOfMilliseconds;
        private SampleDelegate timerDelegate;

        // Constructor
        public Timer(SampleDelegate timerDelegate, int timesOfExecute, int intervalOfMilliseconds)
        {
            this.timerDelegate = timerDelegate;
            this.timesOfExecute = timesOfExecute;
            this.intervalOfMilliseconds = intervalOfMilliseconds;
        }

        // Properties
        public int TimesOfExecute
        {
            get { return this.timesOfExecute; }
            set { this.timesOfExecute = value; }
        }

        public int IntervalOfMilliseconds
        {
            get { return this.intervalOfMilliseconds; }
            set { this.intervalOfMilliseconds = value; }
        }

        public SampleDelegate TimerDelegate
        {
            get { return this.timerDelegate; }
            set { this.timerDelegate = value; }
        }

        // Methods
        // Start timer
        public void TimerExecute()
        {
            for (int i = 0; i < TimesOfExecute; i++)
            {
                Thread.Sleep(IntervalOfMilliseconds);
                TimerDelegate();
            }
        }

        // Print something
        public static void Print()
        {
            Console.WriteLine("Hello world!");
        }
    }
}