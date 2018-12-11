using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class ProductCatalog
    {
        public ProductCatalog()
        {
        }

        private readonly List<Product> ProductsCatalog = new List<Product>()
        {
            new Product
            {
                _title = "CD disk",
                _description = "Size 700mb",
                _price = 140,
                _stock = 17,
                _id = "1"
            },
            new Product
            {
                _title = "PC",
                _description = "Core 2 DUO",
                _price = 20000,
                _stock = 4,
                _id = "2"
            },
            new Product
            {
                _title = "Smartphone",
                _description = "Xiaomi Mi A2",
                _price = 14000,
                _stock = 1000,
                _id = "3"
            },
            new Product
            {
                _title = "Lamp",
                _description = "LED lamp Philips",
                _price = 150,
                _stock = 70,
                _id = "4"
            },
            new Product
            {
                _title = "Pen",
                _description = "Blue pen",
                _price = 3,
                _stock = 1000000,
                _id = "5"
            }
        };

        public void SearchProducts(string substring)
        {
            if (substring.Length == 0)
            {
                Console.WriteLine("Вы ничего не ввели.");
                return;
            }

            var foundProduct = new List<Product>();

            foreach (var product in ProductsCatalog)
            {
                if (product._title.IndexOf(substring, StringComparison.InvariantCultureIgnoreCase) > -1)
                {
                    foundProduct.Add(product);
                }
            }

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

        public Product TryGetFromProductCatalog(Guid findKey, string findId = "")
        {
            foreach (var product in ProductsCatalog)
            {
                if (findKey == product._key || findId == product._id)
                {
                    return product;
                }
            }
            return null;
        }

        public void ShowProductCatalog()
        {
            foreach (var currentProduct in ProductsCatalog)
            {
                currentProduct.ShowProduct();
            }
        }
    }
}