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
            var listProductsInBucket = new List<Bucket>();
            var product = new Product();
            var bucket = new Bucket();
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
                        foreach (var currentProduct in products)
                        {
                            currentProduct.ShowProduct();
                        }
                        break;

                    case "2":
                        Console.Write("Введите строку для поиска: ");
                        string substring = Console.ReadLine();
                        product.SearchProducts(substring, products);
                        break;

                    case "3":
                        Console.Write("Введите ключ товара: ");
                        Guid key = Guid.Parse(Console.ReadLine());
                        bucket.AddToBucketByKey(products, listProductsInBucket, findKey: key);
                        break;

                    case "4":
                        Console.Write("Введите ID товара: ");
                        string id = Console.ReadLine();
                        bucket.AddToBucketByKey(products, listProductsInBucket, findID: id);
                        break;

                    case "5":
                        Console.Write("Корзина товаров: \n");
                        bucket.ShowBucket(listProductsInBucket);
                        break;

                    case "6":
                        Console.Write("Введите ключ удаляемого товара: ");
                        Guid delKey = Guid.Parse(Console.ReadLine());
                        bucket.DelInBucket(listProductsInBucket, findKey: delKey);
                        break;

                    case "7":
                        Console.Write("Введите ключ товара: ");
                        Guid addKey = Guid.Parse(Console.ReadLine());
                        bucket.ChangeInBucket(listProductsInBucket, findKey: addKey);
                        break;

                    case "8":
                        listProductsInBucket.Clear();
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
    }
}
