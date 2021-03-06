﻿using System;
using System.Collections.Generic;

namespace DefiningClasses
{
    class GSM
    {
        // Fields

        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private Battery battery;
        private Display display;
        private static GSM iphone4S = new GSM("IPhone4S", "Apple", 1000, "Some Douche", new Battery("some battery model", 6.5, 2.5, BatteryType.LiIon), new Display(4.5, 16000000));
        private List<Call> callHistory = new List<Call>();
        private const decimal callprice = 0.37M;

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
        public string Manufacturer
        {
            get
            {
                return this.manufacturer;
            }
            set
            {
                this.manufacturer = value;
            }
        }
        public decimal Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Invalid Argument: Price cannot be a negative number.");
                }

                this.price = value;
            }
        }
        public string Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner = value;
            }
        }
        public Battery Battery
        {
            get
            {
                return this.battery;
            }
            set
            {
                this.battery = value;
            }
        }
        public Display Display
        {
            get
            {
                return this.display;
            }
            set
            {
                this.display = value;
            }
        }
        public static GSM IPhone4S
        {
            get
            {
                return iphone4S;
            }
        }
        public List<Call> CallHistory
        {
            get
            {
                return this.callHistory;
            }
            set
            {
                this.callHistory = value;
            }
        }

        // Constructors

        public GSM(string model, string manufacturer) : this (model, manufacturer, 0.0M)
        {

        }
        public GSM(string model, string manufacturer, decimal price) : this (model, manufacturer, price, null)
        {

        }
        public GSM(string model, string manufacturer, decimal price, string owner) : this (model, manufacturer, price, owner, new Battery(null, 0.0, 0.0))
        {

        }
        public GSM(string model, string manufacturer, decimal price, string owner, Battery battery) : this (model, manufacturer, price, owner, battery, new Display(0.0, 0))
        {

        }
        public GSM(string model, string manufacturer, decimal price, string owner, Battery battery, Display display)
        {
            this.Model = model;
            this.Manufacturer = manufacturer;
            this.Price = price;
            this.Owner = owner;
            this.Battery = battery;
            this.Display = display;
        }

        // Methods

        public void ShowInfo()
        {
            Console.WriteLine($"MODEL: {this.Model}\nMANUFACTURER: {this.Manufacturer}\nPRICE: {this.Price}\nOWNER: {this.Owner}\nBATTERY: model -> {this.Battery.Model}; hours idle -> {this.Battery.HoursIdle}; hours talk -> {this.Battery.HoursTalk}; battery type -> {this.Battery.BatteryType}\nDISPLAY: size -> {this.Display.Size}; number of colors -> {this.Display.ColorsCount}");
        }
        public void AddCall(DateTime dateAndtime, int duration, string dialledNumber)
        {
            this.CallHistory.Add(new Call(dateAndtime, duration, dialledNumber));
        }
        public void DeleteCall(int callIndex)
        {
            this.CallHistory.RemoveAt(callIndex);
        }
        public void ClearHistory()
        {
            this.CallHistory.Clear();
        }
        public decimal CalculateCallsPrice()
        {
            int totalSeconds = 0;
            for (int i = 0; i < CallHistory.Count; i++)
            {
                totalSeconds += CallHistory[i].Duration;
            }
            decimal price = (totalSeconds / 60M) * callprice;
            return price;
        }
    }
}
