using System;
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
            var productCatalog = new ProductCatalog();
            var cart = new Cart(productCatalog);
            var collection = new Collections();

            ShowMenu();

            do
            {
                cki = Console.ReadKey();
                var keyPress = cki.KeyChar.ToString();
                switch (keyPress)
                {
                    case "1":
                        productCatalog.ShowProductCatalog();
                        break;

                    case "2":
                        Console.Write("Введите строку для поиска: ");
                        string substring = Console.ReadLine();
                        productCatalog.SearchProducts(substring);
                        break;

                    case "3":
                        Console.Write("Введите ключ товара: ");
                        Guid key = Guid.Parse(Console.ReadLine());
                        cart.AddItemByKey(productKey: key);
                        break;

                    case "4":
                        Console.Write("Введите ID товара: ");
                        string id = Console.ReadLine();
                        cart.AddItemByKey(findID: id);
                        break;

                    case "5":
                        Console.Write("Корзина товаров: \n");
                        cart.ShowCart();
                        break;

                    case "6":
                        Console.Write("Введите ключ удаляемого товара: ");
                        Guid delKey = Guid.Parse(Console.ReadLine());
                        cart.DelInCart(findKey: delKey);
                        break;

                    case "7":
                        Console.Write("Введите ключ товара: ");
                        Guid addKey = Guid.Parse(Console.ReadLine());
                        cart.IncrementItemAmount(findKey: addKey);
                        break;

                    case "8":
                        cart.ClearCart();
                        Console.WriteLine("\nКорзина очищена\n");
                        break;

                    case "9":
                        collection.ExampleList();
                        break;

                    case "0":
                        ShowMenu();
                        break;
                }
            } while (cki.Key != ConsoleKey.Escape);
        }

        static void ShowMenu() =>
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
                $"'9' Показать коллекцию\n" +
                $"'0' Показать меню\n" +
                $"\n*****************************"
            );
     }
}
