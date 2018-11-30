using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Product
    {
        public string title;
        public string description;
        public int price;
        public int stock;
        public string id;
        public string key;

        Guid keyGen = Guid.NewGuid();

        public Product() : this("empty", "empty", 0, 0, "")
        {
        }

        public Product(string title) : this(title, "empty", 0, 0, "")
        {
        }

        public Product(string title, string description) : this(title, description, 0, 0, "")
        {
        }

        public Product(string title, string description, int price) : this(title, description, price, 0, "")
        {
        }

        public Product(string title, string description, int price, int stock) : this(title, description, price, stock, "")
        {
        }

        public Product(string title, string description, int price, int stock, string id)
        {
            this.title = title;
            this.description = description;
            this.price = price;
            this.stock = stock;
            this.id = id;
            key = keyGen.ToString();
        }

        public void ShowProduct()
        {
            Console.WriteLine
                (
                $"Название: {title} \n" +
                $"Описание: {description} \n" +
                $"Стоимость: {price}p \n" +
                $"Количество на складе: {stock}шт \n" +
                $"Ключ: {key}\n" +
                $"ID: {id} \n"
                );
        }
    }
}
