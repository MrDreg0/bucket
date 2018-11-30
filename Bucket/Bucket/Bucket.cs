using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class ProductBucket
    {
        public string key;
        public string id;
        public string title;
        public int price;
        public int amount = 0;
        public int cost = 0;
        public bool added = false;
        DateTime date;

        public ProductBucket() : this("empty", "empty", 0, "")
        {
        }

        public ProductBucket(string key) : this(key, "empty", 0, "")
        {
        }

        public ProductBucket(string key, string title) : this(key, title, 0, "")
        {
        }

        public ProductBucket(string key, string title, int price) : this(key, title, price, "")
        {
        }

        public ProductBucket(string key, string title, int price, string id)
        {
            this.key = key;
            this.title = title;
            this.price = price;
            this.id = id;
            date = SetDate();
        }

        public void ShowProductBucket()
        {
            Console.WriteLine
                (
                $"\nКлюч: {key}\n" +
                $"Название: {title} \n" +
                $"Цена: {price}p \n" +
                $"Количество: {amount}шт \n" +
                $"Стоимость: {cost}р \n" +
                $"Дата добавления: {date} \n"
                );
        }

        public int AddAmount()
        {
            amount += 1;
            return amount;
        }

        public int SumCost()
        {
            cost = amount * price;
            return cost;
        }

        public DateTime SetDate()
        {
            date = DateTime.Now;
            return date;
        }
    }
}
