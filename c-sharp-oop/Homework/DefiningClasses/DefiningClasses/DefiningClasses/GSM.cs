using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DefiningClasses
{
    class GSM
    {
        private string model;
        private string manufacturer;
        private decimal price;
        private string owner;
        private Battery battery;
        private Display display;

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

        public void ShowInfo()
        {
            Console.WriteLine($"MODEL: {this.Model}\nMANUFACTURER: {this.Manufacturer}\nPRICE: {this.Price}\nOWNER: {this.Owner}\nBATTERY: model -> {this.Battery.Model}; hours idle -> {this.Battery.HoursIdle}; hours talk -> {this.Battery.HoursTalk}\nDISPLAY: size -> {this.Display.Size}; number of colors -> {this.Display.ColorsCount}");
        }
    }
}
