using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManagement
{
    class ProductService
    {
        public Product[] products = new Product[0];

        public void Add(Product product)
        {
            Array.Resize(ref products, products.Length + 1);
            products[products.Length - 1] = product;
        }

        public void Edit(Product product)
        {
            var pos = FindProduct(product.Code);
            if(pos != -1)
            {
                products[pos].Name = product.Name;
                products[pos].Price = product.Price;
                products[pos].Manufactory = product.Manufactory;
            }
            else
            {
                Console.WriteLine($"Code: {product.Code} not found");
            }
        }

        public void Delete(string code)
        {
            var pos = FindProduct(code);
            if(pos != -1)
            {
                for(int i=pos; i < products.Length-1; i++)
                {
                    products[i] = products[i + 1];
                }
                Array.Resize(ref products, products.Length - 1);
            }
            else
            {
                Console.WriteLine($"Code: {code} not found");
            }
        }

        public void Show()
        {
            string table = $"Name\tCode\tPrice\tDate\t\tManufactory";
            for(int i=0; i < products.Length; i++)
            {
                table = table + $"\n" + products[i].ShowProductInfo();
            }
            Console.WriteLine(table);
        }

        private int FindProduct(string code)
        {
            for(int i=0; i<products.Length; i++)
            {
                if(products[i].Code.ToUpper() == code.ToUpper())
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
