using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class CartItem
    {
        public Guid _key { get; set; }
        public string _id { get; set; }
        public string _title { get; set; }
        public decimal _price { get; set; }
        public int _amount { get; set; }
        public decimal _cost => _amount * _price;
        public DateTime _date { get; } = DateTime.Now;

        public CartItem (Guid key = default, string title = "empty", decimal price = 0, string id = "")
        {
            _key = key;
            _title = title;
            _price = price;
            _id = id;
        }

        public void ShowCartItem() =>
            Console.WriteLine
                (
                $"\nКлюч: {_key}\n" +
                $"Название: {_title} \n" +
                $"Цена: {_price:C} \n" +
                $"Количество: {_amount}шт \n" +
                $"Стоимость: {_cost:C} \n" +
                $"Дата добавления: {_date} \n"
                );
       
        public int IncrementAmount() =>        
            _amount += 1;    
    }
}
