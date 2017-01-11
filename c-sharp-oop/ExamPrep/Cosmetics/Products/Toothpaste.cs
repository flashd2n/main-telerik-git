using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmetics.Common;

namespace Cosmetics.Products
{
    class Toothpaste : IProduct, IToothpaste
    {
        private string name;

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
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public GenderType Gender { get; set; }
        public string Ingredients { get; set; }

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
            string result = $@"- {this.Brand} - {this.Name}:
    * Price: {this.Price:C2}
    * For gender: {this.Gender}
    * Ingredients: {this.Ingredients}";
            return result;
        }
    }
}
