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
            ConsoleKeyInfo cki;
            List<ProductBucket> Bucket = new List<ProductBucket>();
            var products = new[]
            {
                new Product
                {
                    title = "CD disk",
                    description = "Size 700mb",
                    price = 140,
                    stock = 17,
                    id = "1"
                },
                new Product
                {
                    title = "PC",
                    description = "Core 2 DUO",
                    price = 20000,
                    stock = 4,
                    id = "2"
                },
                new Product
                {
                    title = "Smartphone",
                    description = "Xiaomi Mi A2",
                    price = 14000,
                    stock = 1000,
                    id = "3"
                },
                new Product
                {
                    title = "Lamp",
                    description = "LED lamp Philips",
                    price = 150,
                    stock = 70,
                    id = "4"
                },
                new Product
                {
                    title = "Pen",
                    description = "Blue pen",
                    price = 3,
                    stock = 1000000,
                    id = "5"
                }
            };

            ShowMenu();

            do
            {
                cki = Console.ReadKey();

                string keyPress = cki.KeyChar.ToString();

                switch (keyPress)
                {
                    case "1":
                        foreach (var p in products)
                        {
                            p.ShowProduct();
                        }
                        break;

                    case "2":
                        Console.Write("Введите строку для поиска: ");
                        string s = Console.ReadLine();
                        SearchProducts(s, products);
                        break;

                    case "3":
                        Console.Write("Введите ключ товара: ");
                        string key = Console.ReadLine();
                        AddInBucket(products, Bucket, findKey: key);
                        break;

                    case "4":
                        Console.Write("Введите ID товара: ");
                        string id = Console.ReadLine();
                        AddInBucket(products, Bucket, findID: id);
                        break;

                    case "5":
                        Console.Write("Корзина товаров: \n");
                        ShowBucket(Bucket);
                        break;

                    case "6":
                        Console.Write("Введите ключ удаляемого товара: ");
                        string delKey = Console.ReadLine();
                        DelInBucket(Bucket, findKey: delKey);
                        break;

                    case "7":
                        Console.Write("Введите ключ товара: ");
                        string addKey = Console.ReadLine();
                        ChangeInBucket(Bucket, findKey: addKey);
                        break;

                    case "8":
                        Bucket.Clear();
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

        static void SearchProducts(string s, Product[] products)
        {
            if (s.Length == 0)
            {
                Console.WriteLine("Вы ничего не ввели.");
            }
            else
            {
                List<Product> foundProduct = new List<Product>();
                for (int i = 0; i < products.Length; i++)
                {
                    string product = products[i].title.ToLower();
                    string substring = s.ToLower();

                    if (product.IndexOf(substring) > -1)
                    {
                        foundProduct.Add(products[i]);
                    }
                }

                if (foundProduct.Count() == 0)
                {
                    Console.WriteLine("Товаров по Вашему запросу не найдено.");
                }
                else
                {
                    Console.WriteLine("\nНайдено товаров: \n", foundProduct.Count());
                    foreach (Product p in foundProduct)
                    {
                        p.ShowProduct();
                    }
                }

            }
        }
        static void AddInBucket(Product[] products, List<ProductBucket> bucket, string findKey = "", string findID = "")
        {
            if (findKey.Length == 0 && findID.Length == 0)
            {
                Console.WriteLine("Вы ничего не ввели.");
                return;
            }
            else
            {
                for (int i = 0; i < products.Length; i++)
                {
                    string productKey = products[i].key;
                    string productId = products[i].id;
                    if (productKey == findKey || productId == findID)
                    {
                        foreach (ProductBucket p in bucket)
                        {
                            if (findKey == p.key)
                            {
                                p.AddAmount();
                                p.SumCost();
                                Console.WriteLine("\nТовар добавлен!\n");
                                return;
                            }
                            else if (findID == p.id)
                            {
                                p.AddAmount();
                                p.SumCost();
                                Console.WriteLine("\nТовар добавлен!\n");
                                return;
                            }
                        }

                        ProductBucket productBucket = new ProductBucket
                        {
                            key = products[i].key,
                            title = products[i].title,
                            price = products[i].price,
                            id = products[i].id
                        };
                        productBucket.AddAmount();
                        productBucket.SumCost();
                        bucket.Add(productBucket);
                        Console.WriteLine("\nТовар добавлен!\n");
                    }
                }
            }
        }

        static void DelInBucket(List<ProductBucket> bucket, string findKey = "")
        {
            if (findKey.Length == 0)
            {
                Console.WriteLine("Вы ничего не ввели.");
                return;
            }
            else
            {
                for(int i = 0; i < bucket.Count(); i++)
                {
                    if (findKey == bucket[i].key)
                    {
                        bucket.Remove(bucket[i]);
                        Console.WriteLine("Товар удален");
                    }
                }
            }
        }

        static void ChangeInBucket(List<ProductBucket> bucket, string findKey = "")
        {
            if (findKey.Length == 0)
            {
                Console.WriteLine("Вы ничего не ввели.");
                return;
            }
            else
            {
                for (int i = 0; i < bucket.Count(); i++)
                {
                    if (findKey == bucket[i].key)
                    {
                        bucket[i].AddAmount();
                        bucket[i].SumCost();
                        Console.WriteLine("Товар добавлен");
                    }
                }

            }
        }

        static void ShowBucket(List<ProductBucket> bucket)
        {
            if (bucket.Count() == 0)
            {
                Console.WriteLine("\nВ корзине нет товаров.");
            }
            else
            {
                int sumCost = 0;
                int sumAmount = 0;
                foreach (ProductBucket p in bucket)
                {
                    sumCost += p.cost;
                    sumAmount += p.amount;
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
}
