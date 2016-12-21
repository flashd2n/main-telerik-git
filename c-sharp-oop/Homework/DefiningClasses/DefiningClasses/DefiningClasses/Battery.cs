using System;

namespace DefiningClasses
{
    class Battery
    {
        // Fields

        private string model;
        private double hoursIdle;
        private double hoursTalk;
        private BatteryType batteryType;

        // Properties

        public string Model
        {
            get
            {
                return this.model;
            }

            set
            {
                this.model = value;
            }
        }
        public double HoursIdle
        {
            get
            {
                return this.hoursIdle;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid argument: Hours Idle must be a positive number");
                }

                this.hoursIdle = value;
            }
        }
        public double HoursTalk
        {
            get
            {
                return this.hoursTalk;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid argument: Hours Talk must be a positive number");
                }

                this.hoursTalk = value;
            }
        }
        public BatteryType BatteryType
        {
            get
            {
                return this.batteryType;
            }
            set
            {
                this.batteryType = value;
            }
        }

        // Constructors

        public Battery(string model, double hoursIdle, double hoursTalk) : this (model, hoursIdle, hoursTalk, new BatteryType())
        {
        }
        public Battery(string model, double hoursIdle, double hoursTalk, BatteryType batteryType)
        {
            this.Model = model;
            this.HoursIdle = hoursIdle;
            this.HoursTalk = hoursTalk;
            this.BatteryType = batteryType;
        }
    }

    enum BatteryType
    {
        LiIon, NiMH, NiCd
    }
}
