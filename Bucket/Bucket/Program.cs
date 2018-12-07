using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            ConsoleKeyInfo cki;
            var bucket = new List<ProductBucket>();
            var products = new[]
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

            ShowMenu();

            do
            {
                cki = Console.ReadKey();

                var keyPress = cki.KeyChar.ToString();

                switch (keyPress)
                {
                    case "1":
                        foreach (var product in products)
                        {
                            product.ShowProduct();
                        }
                        break;

                    case "2":
                        Console.Write("Введите строку для поиска: ");
                        string s = Console.ReadLine();
                        SearchProducts(s, products);
                        break;

                    case "3":
                        Console.Write("Введите ключ товара: ");
                        Guid key = Guid.Parse(Console.ReadLine());
                        AddToBucketByKey(products, bucket, findKey: key);
                        break;

                    case "4":
                        Console.Write("Введите ID товара: ");
                        string id = Console.ReadLine();
                        AddToBucketByKey(products, bucket, findID: id);
                        break;

                    case "5":
                        Console.Write("Корзина товаров: \n");
                        ShowBucket(bucket);
                        break;

                    case "6":
                        Console.Write("Введите ключ удаляемого товара: ");
                        Guid delKey = Guid.Parse(Console.ReadLine());
                        DelInBucket(bucket, findKey: delKey);
                        break;

                    case "7":
                        Console.Write("Введите ключ товара: ");
                        Guid addKey = Guid.Parse(Console.ReadLine());
                        ChangeInBucket(bucket, findKey: addKey);
                        break;

                    case "8":
                        bucket.Clear();
                        Console.WriteLine("\nКорзина очищена\n");
                        break;

                    case "0":
                        ShowMenu();
                        break;
                }
            } while (cki.Key != ConsoleKey.Escape);
        }

        static void ShowMenu()
        {
            Console.WriteLine(
                $"\n*********** Меню ************\n\n" +
                $"'1' Показать список товаров\n" +
                $"'2' Поиск товаров\n" +
                $"'3' Добавить товар в корзину по ключу\n" +
                $"'4' Добавить товар в корзину по ID\n" +
                $"'5' Показать корзину товаров\n" +
                $"'6' Удалить товар по ключу\n" +
                $"'7' Добавить товар по ключу\n" +
                $"'8' Очистить корзину\n" +
                $"'0' Показать меню\n" +
                $"\n*****************************"
            );
        }

        static void SearchProducts(string substring, Product[] products)
        {
            if (substring.Length == 0)
            {
                Console.WriteLine("Вы ничего не ввели.");
                return;
            }

            var foundProduct = new List<Product>();

            foreach (var product in products)
            {
                if (product.Title.IndexOf(substring, StringComparison.InvariantCultureIgnoreCase) > -1)
                {
                    foundProduct.Add(product);
                }
            }

            if (foundProduct.Count() == 0)
            {
                Console.WriteLine("Товаров по Вашему запросу не найдено.");
            }
            else
            {
                Console.WriteLine("\nНайдено товаров: {0} \n", foundProduct.Count());
                foreach (Product product in foundProduct)
                {
                    product.ShowProduct();
                }
            }
        }

        static void AddToBucketByKey(Product[] products, IList<ProductBucket> bucket, Guid findKey = default, string findID = "")
        {
            if (findKey.Equals(Guid.Empty) && String.IsNullOrEmpty(findID))
            {
                Console.WriteLine("Вы ничего не ввели.");
                return;
            }

            var productInList = TryGetFromProductList(products, findKey, findID);

            if (productInList == null)
            {
                Console.WriteLine("Товар не найден.");
                return;
            }

            var productInBucket = TryGetFromBucket(bucket, findKey, findID);

            if (productInBucket != null)
            {
                productInBucket.IncrementAmount();
                Console.WriteLine("\nТовар добавлен!\n");
                return;
            }    
            AddToBucket(bucket, productInList);
        }

        static void AddToBucket (IList<ProductBucket> bucket, Product product)
        {
            ProductBucket productBucket = new ProductBucket
            {
                Key = product.Key,
                Title = product.Title,
                Price = product.Price,
                Id = product.Id
            };
            productBucket.IncrementAmount();
            bucket.Add(productBucket);
            Console.WriteLine("\nТовар добавлен!\n");
        }

        static void DelInBucket(List<ProductBucket> bucket, Guid findKey)
        {
            if (findKey.Equals(Guid.Empty))
            {
                Console.WriteLine("Вы ничего не ввели.");
                return;
            }

            var item = TryGetFromBucket(bucket, findKey);
            if (item == null)
            {
                Console.WriteLine("\nТовар не найден\n");
                return;
            }
            bucket.Remove(item);
            Console.WriteLine("\nТовар удален\n");
        }

        static Product TryGetFromProductList (Product[] products, Guid findKey, string findId = "")
        {
            foreach (var product in products)
            {
                if (findKey == product.Key || findId == product.Id)
                {
                    return product;
                }
            }
            return null;
        }

        static ProductBucket TryGetFromBucket (IList<ProductBucket> bucket, Guid findKey, string findId = "")
        {
            foreach (var product in bucket)
            {
                if (findKey == product.Key || findId == product.Id)
                {
                    return product;
                }
            }
            return null;
        }

        static void ChangeInBucket(List<ProductBucket> bucket, Guid findKey)
        {
            if (findKey.Equals(Guid.Empty))
            {
                Console.WriteLine("Вы ничего не ввели.");
                return;
            }

            foreach (var product in bucket)
            {
                if (findKey == product.Key)
                {
                    product.IncrementAmount();
                    Console.WriteLine("Товар добавлен");
                    return;
                }
            }
        }

        static void ShowBucket(List<ProductBucket> bucket)
        {
            if (bucket.Count() == 0)
            {
                Console.WriteLine("\nВ корзине нет товаров.");
                return;
            }

            var sumCost = 0M;
            var sumAmount = 0;
            foreach (ProductBucket p in bucket)
            {
                sumCost += p.Cost;
                sumAmount += p.Amount;
                p.ShowProductBucket();
            }
            Console.WriteLine
                (
                    $"-------------------------------------------" +
                    $"\nКоличество товаров в корзине: " + sumAmount +
                    $"\nОбщая стоимость: " + sumCost + "\n"
                );
        }
    }
}
