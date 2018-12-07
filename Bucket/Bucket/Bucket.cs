using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Bucket
    {
        private Guid Key { get; set; }
        private string Id { get; set; }
        private string Title { get; set; }
        private decimal Price { get; set; }
        private int Amount { get; set; }
        private decimal Cost => Amount * Price;
        private DateTime Date { get; } = DateTime.Now;

        internal Bucket(Guid key = default, string title = "empty", decimal price = 0, string id = "")
        {
            Key = key;
            Title = title;
            Price = price;
            Id = id;
        }

        internal void ShowProductBucket()
        {
            Console.WriteLine
                (
                $"\nКлюч: {Key}\n" +
                $"Название: {Title} \n" +
                $"Цена: {Price:C}p \n" +
                $"Количество: {Amount}шт \n" +
                $"Стоимость: {Cost:C} \n" +
                $"Дата добавления: {Date} \n"
                );
        }

        internal int IncrementAmount()
        {
            Amount += 1;
            return Amount;
        }

        internal void AddToBucketByKey(Product[] products, IList<Bucket> bucket, Guid findKey = default, string findID = "")
        {
            if (findKey.Equals(Guid.Empty) && String.IsNullOrEmpty(findID))
            {
                Console.WriteLine("Вы ничего не ввели.");
                return;
            }
            var product = new Product();
            var productInList = product.TryGetFromProductList(products, findKey, findID);

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

        internal void AddToBucket(IList<Bucket> bucket, Product product)
        {
            Bucket Bucket = new Bucket
            {
                Key = product.Key,
                Title = product.Title,
                Price = product.Price,
                Id = product.Id
            };
            Bucket.IncrementAmount();
            bucket.Add(Bucket);
            Console.WriteLine("\nТовар добавлен!\n");
        }

        internal void DelInBucket(List<Bucket> bucket, Guid findKey)
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

        private Bucket TryGetFromBucket(IList<Bucket> bucket, Guid findKey, string findId = "")
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

        internal void ShowBucket(List<Bucket> bucket)
        {
            if (bucket.Count() == 0)
            {
                Console.WriteLine("\nВ корзине нет товаров.");
                return;
            }

            var sumCost = 0M;
            var sumAmount = 0;
            foreach (Bucket p in bucket)
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
        internal void ChangeInBucket(List<Bucket> bucket, Guid findKey)
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
    }
}
