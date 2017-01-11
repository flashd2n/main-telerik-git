using Cosmetics.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Common
{
    class Category : ICategory
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
                if (value.Length >= 2 && value.Length <= 15)
                {
                    this.name = value;
                }
                else
                {
                    Console.WriteLine("Category name must be between 2 and 15 symbols long!");
                }
            }
        }

        private List<IProduct> productsInCategory;

        public Category(string name)
        {
            this.Name = name;
            this.productsInCategory = new List<IProduct>();
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.productsInCategory.Add(cosmetics);
            this.productsInCategory = this.productsInCategory.OrderBy(x => x.Brand).ThenByDescending(y => y.Price).ToList();

        }

        public string Print()
        {
            var result = new StringBuilder();
            if (this.productsInCategory.Count == 0)
            {
                result.Append($"{this.Name} category – {this.productsInCategory.Count} products in total");
            }
            else if (this.productsInCategory.Count == 1)
            {
                result.Append($"{this.Name} category – {this.productsInCategory.Count} product in total\n");
                result.Append(this.productsInCategory[0].Print());
            }
            else
            {
                result.Append($"{this.Name} category – {this.productsInCategory.Count} products in total\n");
                for (int i = 0; i < this.productsInCategory.Count; i++)
                {
                    result.Append(this.productsInCategory[i].Print());
                }
            }

            return result.ToString();
        }

        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (this.productsInCategory.Contains(cosmetics))
            {
                this.productsInCategory.Remove(cosmetics);
            }
            else
            {
                Console.WriteLine($"Product {cosmetics.Name} does not exist in category {this.Name}!");
            }
        }
    }
}
