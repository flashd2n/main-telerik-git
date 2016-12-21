using System;

namespace DefiningClasses
{
    class Call
    {
        // Fields

        private DateTime dateAndTime;
        private int duration;
        private string dialledNumber;

        // Properties

        public DateTime DateAndTime
        {
            get
            {
                return this.dateAndTime;
            }
            set
            {
                this.dateAndTime = value;
            }
        }
        public int Duration
        {
            get
            {
                return this.duration;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid Argument: Duration cannot be a negative number");
                }

                this.duration = value;
            }
        }
        public string DialledNumber
        {
            get
            {
                return this.dialledNumber;
            }
            set
            {
                this.dialledNumber = value;
            }
        }

        // Constructor

        public Call(DateTime dateAndTime, int duration, string dialledNumber)
        {
            this.DateAndTime = dateAndTime;
            this.Duration = duration;
            this.DialledNumber = dialledNumber;
        }

    }
}
