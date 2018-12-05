using System;
using System.Globalization;

namespace Shop
{
    public class ProductBucket
    {
        public Guid Key { get; set; }
        public string Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
        public decimal Cost { get => Amount * Price; }
        public DateTime Date { get; } = DateTime.Now; 

        public ProductBucket(Guid key = new Guid(), string title = "empty", decimal price = 0, string id = "")
        {
            Key = key;
            Title = title;
            Price = price;
            Id = id;
        }

        public void ShowProductBucket()
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

        public int IncrementAmount()
        {
            Amount += 1;
            return Amount;
        }
    }
}
