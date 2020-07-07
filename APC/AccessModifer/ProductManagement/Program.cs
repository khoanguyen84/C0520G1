using System;

namespace ProductManagement
{
    class Program
    {
        public static ProductService ProductService = new ProductService();
        static void Main(string[] args)
        {
            CreateProduct();
            CreateProduct();
            CreateProduct();
            ProductService.Show();
            RemoveProduct();
            ProductService.Show();
        }

        public static void CreateProduct()
        {
            //var product = new Product();
            //Console.Write("Product name: ");
            //product.Name = Console.ReadLine();
            //Console.Write("Product Code: ");
            //product.Code = Console.ReadLine();
            //Console.Write("Price: ");
            //product.Price = double.Parse(Console.ReadLine());
            //Console.Write("Product date: ");
            //product.Date = DateTime.Parse(Console.ReadLine());
            //Console.Write("Manufactory: ");
            //product.Manufactory = Console.ReadLine();
            Random rnd = new Random();
            var product = new Product()
            {
                Code = rnd.Next(1000,9999).ToString(),
                Date = DateTime.Parse("2020/07/07"),
                Manufactory = "USA",
                Name = "IP6",
                Price = 5000000
            };
            ProductService.Add(product);
        }

        public static void RemoveProduct()
        {
            Console.Write("Enter code: ");
            var code = Console.ReadLine();
            ProductService.Delete(code);
        }
    }
}
