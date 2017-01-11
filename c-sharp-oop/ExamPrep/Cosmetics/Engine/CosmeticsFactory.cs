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
            var newCategory = new Category(name);
            return newCategory as ICategory;
        }

        public Shampoo CreateShampoo(string name, string brand, decimal price, GenderType gender, uint milliliters, UsageType usage)
        {
            var newShampoo = new Shampoo(name, brand, price, gender, milliliters, usage);
            return newShampoo;
        }

        public IToothpaste CreateToothpaste(string name, string brand, decimal price, GenderType gender, IList<string> ingredients)
        {
            string passIngredients = string.Join(", ", ingredients);
            var newToothpaste = new Toothpaste(name, brand, price, gender, passIngredients);
            return newToothpaste as IToothpaste;
        }

        public ShoppingCart ShoppingCart()
        {
            var newShoppingCard = new ShoppingCart();
            return newShoppingCard;
        }
    }
}
