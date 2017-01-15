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
                Validator.CheckIfStringLengthIsValid(value, 10, 3, string.Format(GlobalErrorMessages.InvalidStringLength, "Product name", 3, 10));
                this.name = value;
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
                Validator.CheckIfStringLengthIsValid(value, 10, 2, string.Format(GlobalErrorMessages.InvalidStringLength, "Product brand", 2, 10));
                this.brand = value;
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

            var result = new StringBuilder();

            result.Append($@"- {this.Brand} - {this.Name}:
  * Price: {this.Price:C2}
  * For gender: {this.Gender}
  * Quantity: {this.Milliliters} ml
  * Usage: {this.Usage}");
            return result.ToString();

        }
    }
}
