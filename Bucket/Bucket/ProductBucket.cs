using System;
using System.Globalization;

namespace Shop
{
    public class ProductBucket
    {
        public string Key { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public decimal Cost { get => Amount * Price; }
        DateTime date;

        public ProductBucket(string key = "", string title = "empty", decimal price = 0, string id = "")
        {
            Key = key;
            Title = title;
            Price = price;
            Id = id;
            SetCurrentDate();
        }

        public void ShowProductBucket()
        {
            Console.WriteLine
                (
                $"\nКлюч: {Key}\n" +
                $"Название: {Title} \n" +
                $"Цена: {Price.ToString("C", CultureInfo.CurrentCulture)}p \n" +
                $"Количество: {Amount}шт \n" +
                $"Стоимость: {Cost.ToString("C", CultureInfo.CurrentCulture)} \n" +
                $"Дата добавления: {date} \n"
                );
        }

        public int IncrementAmount()
        {
            Amount += 1;
            return Amount;
        }
            

        public void SetCurrentDate()
            => date = DateTime.Now;
    }
}
