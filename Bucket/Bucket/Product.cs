using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Product
    {
        public string _title { get; set; }
        public string _description { get; set; }
        public decimal _price { get; set; }
        public int _stock { get; set; }
        public string _id { get; set; }
        public Guid _key { get; } = Guid.NewGuid();

        public Product(string title = "empty", string description = "empty", decimal price = 0, int stock = 0, string id = "")
        {
            _title = title;
            _description = description;
            _price = price;
            _stock = stock;
            _id = id;
        }

        public void ShowProduct() =>
            Console.WriteLine
                (
                $"Название: {_title} \n" +
                $"Описание: {_description} \n" +
                $"Стоимость: {_price:C} \n" +
                $"Количество на складе: {_stock}шт \n" +
                $"Ключ: {_key}\n" +
                $"ID: {_id} \n"
                );
    }
}
