using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Product
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Id { get; set; }
        public Guid Key { get; set; } = Guid.NewGuid();

        public Product(string title = "empty", string description = "empty", decimal price = 0, int stock = 0, string id = "")
        {
            Title = title;
            Description = description;
            Price = price;
            Stock = stock;
            Id = id;
        }

        public void ShowProduct()
        {
            Console.WriteLine
                (
                $"Название: {Title} \n" +
                $"Описание: {Description} \n" +
                $"Стоимость: {Price:C} \n" +
                $"Количество на складе: {Stock}шт \n" +
                $"Ключ: {Key}\n" +
                $"ID: {Id} \n"
                );
        }
    }
}
