namespace Cosmetics.Engine
{
    using System.Collections.Generic;

    using Cosmetics.Common;
    using Cosmetics.Contracts;
    using Cosmetics.Products;
    using Cart;
	
    public class CosmeticsFactory : ICosmeticsFactory
    {
        public ICategory CreateCategory(string name)
        {
            var newCat = new Category(name);
            return newCat as ICategory;
        }

        public Shampoo CreateShampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
        {
            var newShampoo = new Shampoo(name, brand, price, gender, milliliters, usage);
            return newShampoo;
        }

        public IToothpaste CreateToothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
        {
            foreach (var ingredient in ingredients)
            {
                Validator.CheckIfStringLengthIsValid(ingredient, 12, 4, string.Format(GlobalErrorMessages.InvalidStringLength, "Each ingredient", 4, 12));
            }
            var ingredientsToPass = string.Join(", ", ingredients);
            var toothpaste = new Toothpaste(name, brand, price, gender, ingredientsToPass);
            return toothpaste as IToothpaste;
        }

        public ShoppingCart ShoppingCart()
        {
            var newShop = new ShoppingCart();
            return newShop;
        }
    }
}
