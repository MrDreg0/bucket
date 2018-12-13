using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class CartItem
    {
        public Guid Key { get; set; }
        public string Id { get; set; }
        private string Title { get; set; }
        private decimal Price { get; set; }
        public int Amount { get; set; }
        public decimal Cost => Amount * Price;
        private DateTime Date { get; } = DateTime.Now;

        public CartItem (Guid key = default, string title = "empty", decimal price = 0, string id = "")
        {
            Key = key;
            Title = title;
            Price = price;
            Id = id;
        }

        public void ShowCartItem() =>
            Console.WriteLine
                (
                $"\nКлюч: {Key}\n" +
                $"Название: {Title} \n" +
                $"Цена: {Price:C} \n" +
                $"Количество: {Amount}шт \n" +
                $"Стоимость: {Cost:C} \n" +
                $"Дата добавления: {Date} \n"
                );
       
        public int IncrementAmount() =>        
            Amount += 1;    
    }
}
