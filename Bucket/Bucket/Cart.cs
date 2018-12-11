using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Cart
    {
        private List<CartItem> CartItems = new List<CartItem>();
        private ProductCatalog _catalog;

        public Cart()
        {
        }

        public Cart(ProductCatalog catalog)
        {
            _catalog = catalog;
        }

        public void AddToCartByKey(Guid findKey = default, string findID = "")
        {
            if (findKey.Equals(Guid.Empty) && String.IsNullOrEmpty(findID))
            {
                Console.WriteLine("Вы ничего не ввели.");
                return;
            }
            var itemInProductCatalog = _catalog.TryGetFromProductCatalog(findKey, findID);

            if (itemInProductCatalog == null)
            {
                Console.WriteLine("Товар не найден.");
                return;
            }

            var productInCart = TryGetFromCart(findKey, findID);

            if (productInCart > -1)
            {
                CartItems[productInCart].IncrementAmount();
                Console.WriteLine("\nТовар добавлен!\n");
                return;
            }
            AddToCart(itemInProductCatalog);
        }

        private void AddToCart(Product product)
        {
            var Item = new CartItem
            (
                product._key,
                product._title,
                product._price,
                product._id
            );
            Item.IncrementAmount();
            CartItems.Add(Item);
            Console.WriteLine("\nТовар добавлен!\n");
        }

        public void DelInCart(Guid findKey)
        {
            if (findKey.Equals(Guid.Empty))
            {
                Console.WriteLine("Вы ничего не ввели.");
                return;
            }

            var item = TryGetFromCart(findKey);
            if (item == -1)
            {
                Console.WriteLine("\nТовар не найден\n");
                return;
            }
            CartItems.Remove(CartItems[item]);
            Console.WriteLine("\nТовар удален\n");
        }

        public int TryGetFromCart(Guid findKey, string findId = "")
        {
            foreach (var product in CartItems)
            {
                if (findKey == product._key || findId == product._id)
                {
                    return CartItems.IndexOf(product);
                }
            }
            return -1;
        }

        public void ShowCart()
        {
            if (CartItems.Count() == 0)
            {
                Console.WriteLine("\nВ корзине нет товаров.");
                return;
            }

            var sumCost = 0M;
            var sumAmount = 0;

            foreach (var item in CartItems)
            {
                sumCost += item._cost;
                sumAmount += item._amount;
                item.ShowCartItem();
            }
            Console.WriteLine
                (
                    $"-------------------------------------------" +
                    $"\nКоличество товаров в корзине: " + sumAmount +
                    $"\nОбщая стоимость: " + sumCost + "\n"
                );
        }

        public void ChangeInCart(Guid findKey)
        {
            if (findKey.Equals(Guid.Empty))
            {
                Console.WriteLine("Вы ничего не ввели.");
                return;
            }

            foreach (var product in CartItems)
            {
                if (findKey == product._key)
                {
                    product.IncrementAmount();
                    Console.WriteLine("Товар добавлен");
                    return;
                }
            }
        }

        public void ClearCart()
        {
            CartItems.Clear();
        }
    }
}
