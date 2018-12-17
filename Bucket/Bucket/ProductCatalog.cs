using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class ProductCatalog
    {
        private readonly List<Product> _products = new List<Product>()
        {
            new Product
            {
                Title = "CD disk",
                Description = "Size 700mb",
                Price = 140,
                Stock = 17,
                Id = "1"
            },
            new Product
            {
                Title = "PC",
                Description = "Core 2 DUO",
                Price = 20000,
                Stock = 4,
                Id = "2"
            },
            new Product
            {
                Title = "Smartphone",
                Description = "Xiaomi Mi A2",
                Price = 14000,
                Stock = 1000,
                Id = "3"
            },
            new Product
            {
                Title = "Lamp",
                Description = "LED lamp Philips",
                Price = 150,
                Stock = 70,
                Id = "4"
            },
            new Product
            {
                Title = "Pen",
                Description = "Blue pen",
                Price = 3,
                Stock = 1000000,
                Id = "5"
            }
        };

        public void SearchProducts(string substring)
        {
            if (string.IsNullOrEmpty(substring))
            {
                Console.WriteLine("Вы ничего не ввели.");
                return;
            }

            var foundProduct = _products.Where(product => product.Title.Contains(substring));

            if (foundProduct.Count() == 0)
            {
                Console.WriteLine("Товаров по Вашему запросу не найдено.");
                return;
            }
            Console.WriteLine("\nНайдено товаров: {0} \n", foundProduct.Count());
            foreach (Product product in foundProduct)
            {
                product.ShowProduct();
            }
        }

        public Product TryGetProduct(Guid findKey, string findId = "")
        {
            foreach (var product in _products)
            {
                if (findKey == product.Key || findId == product.Id)
                {
                    return product;
                }
            }
            return null;
        }

        public void ShowProductCatalog()
        {
            foreach (var currentProduct in _products)
            {
                currentProduct.ShowProduct();
            }
        }
    }
}