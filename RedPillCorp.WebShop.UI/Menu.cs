using RedPillCorp.WebShop.Core.IServices;
using System;

namespace RedPillCorp.WebShop.UI
{
    public class Menu
    {
        private IProductService _productService;

        public Menu(IProductService productService)
        {
            _productService = productService;
        }

        public void Start()
        {
            ListAllIds();
            ShowMostExpensiveProduct();
            Console.ReadLine();
        }

        private void ListAllIds()
        {
            Console.WriteLine("List of all your products");
            Console.WriteLine("");
            var products = _productService.GetAllIdsAndNames();

            foreach (var product in products)
            {
                Console.WriteLine($"Product: {product.Item1}, {product.Item2}");
            }
        }

        public void ShowMostExpensiveProduct()
        {
            Console.WriteLine("Most Expensive product:");
            Console.WriteLine("Product: " + _productService.GetMostExpensiveProduct().Name + " Price: " + _productService.GetMostExpensiveProduct().Price);
        }
    }
}
