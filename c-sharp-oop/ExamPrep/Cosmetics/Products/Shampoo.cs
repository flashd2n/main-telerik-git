using Cosmetics.Common;
using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Products
{
    public class Shampoo : IShampoo, IProduct
    {
        private decimal price;
        private string name;
        private string brand;

        public Shampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price * milliliters;
            this.Gender = gender;
            this.Milliliters = milliliters;
            this.Usage = usage;

        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length >= 3 && value.Length <= 10)
                {
                    this.name = value;
                }
                else
                {
                    Console.WriteLine("Product name must be between 3 and 10 symbols long!");
                }
            }
        }

        public string Brand
        {
            get
            {
                return this.brand;
            }
            protected set
            {

                if (value.Length >= 2 && value.Length <= 10)
                {
                    this.brand = value;
                }
                else
                {
                    Console.WriteLine("Product brand must be between 2 and 10 symbols long!");
                }
            }
        }

        public decimal Price
        {
            get
            {
                return this.price;
            }
            protected set
            {

                this.price = value;
            }
        }

        public GenderType Gender { get; set; }

        public uint Milliliters { get; set; }

        public UsageType Usage { get; set; }

        public string Print()
        {
            string result = $@"- {this.Brand} - {this.Name}:
    * Price: {this.Price:C2}
    * For gender: {this.Gender}
    * Quantity: {this.Milliliters} ml
    * Usage: {this.Usage}";
            return result;
        }
    }
}
