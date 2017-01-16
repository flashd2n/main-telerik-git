using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;

namespace Cosmetics.Products
{
    public class Toothpaste : IProduct, IToothpaste
    {
        private string name;
        private string brand;

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
            set
            {
                Validator.CheckIfStringLengthIsValid(value, 10, 2, string.Format(GlobalErrorMessages.InvalidStringLength, "Product brand", 2, 10));
                this.brand = value;
            }
        }
        public decimal Price { get; set; }
        public string Ingredients { get; set; }
        public GenderType Gender { get; set; }

        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.Gender = gender;
            this.Ingredients = ingredients;
        }


        public string Print()
        {
            var result = new StringBuilder();

            result.Append($@"- {this.Brand} - {this.Name}:
  * Price: {this.Price:C2}
  * For gender: {this.Gender}
  * Ingredients: {this.Ingredients}");
            return result.ToString();
        }
    }
}
