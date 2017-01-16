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
        private List<IProduct> allProducts;

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                Validator.CheckIfStringIsNullOrEmpty(value, string.Format(GlobalErrorMessages.StringCannotBeNullOrEmpty, "Category"));
                Validator.CheckIfStringLengthIsValid(value, 15, 2, string.Format(GlobalErrorMessages.InvalidStringLength, "Category name", 2, 15));
                this.name = value;
            }
        }


        public Category(string name)
        {
            this.allProducts = new List<IProduct>();
            this.Name = name;
        }

        public void AddCosmetics(IProduct cosmetics)
        {
            this.allProducts.Add(cosmetics);
        }


        public void RemoveCosmetics(IProduct cosmetics)
        {
            if (!allProducts.Contains(cosmetics))
            {
                throw new ArgumentNullException($"Product {cosmetics.Name} does not exist in category {this.Name}");
            }
            else
            {
                this.allProducts.Remove(cosmetics);
            }
        }



        public string Print()
        {
            var orderedCat = this.allProducts.OrderBy(x => x.Brand).ThenByDescending(y => y.Price);

            var result = new StringBuilder();


            if (this.allProducts.Count == 0)
            {
                result.Append($"{this.Name} category - {this.allProducts.Count} products in total");
            }
            else if (this.allProducts.Count == 1)
            {
                result.Append($"{this.Name} category - {this.allProducts.Count} product in total");

                foreach (var product in orderedCat)
                {
                    result.Append($"\n{product.Print()}");
                }
            }
            else
            {
                result.Append($"{this.Name} category - {this.allProducts.Count} products in total");

                foreach (var product in orderedCat)
                {
                    result.Append($"\n{product.Print()}");
                }
            }

            return result.ToString();
        }
    }
}
