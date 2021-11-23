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
            Console.ReadLine();
            ShowMostExpensiveProduct();
            Console.ReadLine();
            ShowCheapestProduct();
            Console.ReadLine();
        }

        private void ListAllIds()
        {
            Console.WriteLine("List of all your products");
           
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

        public void ShowCheapestProduct()
        {
            Console.WriteLine("Cheapest product:");
            Console.WriteLine("Product: " + _productService.GetCheapestProduct().Name + " Price: " + _productService.GetCheapestProduct().Price);
        }
    }
}
