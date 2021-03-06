﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    public class Cart
    {
        private readonly List<CartItem> _cartItems = new List<CartItem>();
        private readonly ProductCatalog _catalog;
        private decimal TotalCost 
            => _cartItems.Sum(item => item.Cost);
        private int TotalAmount
            => _cartItems.Sum(item => item.Amount);

        public Cart(ProductCatalog catalog)
        {
            _catalog = catalog ?? throw new ArgumentNullException(nameof(catalog), "Вы не выбрали каталог товаров.");
        }

        public void AddItemByKey(Guid productKey = default, string findID = "")
        {
            if (productKey == default && string.IsNullOrEmpty(findID))
            {
                Console.WriteLine("Вы ничего не ввели.");
                return;
            }
            var itemInProductCatalog = _catalog.TryGetProduct(productKey, findID);

            if (itemInProductCatalog == null)
            {
                Console.WriteLine("Товар не найден.");
                return;
            }

            var productInCart = TryGetItemIndex(productKey, findID);

            if (productInCart > -1)
            {
                IncrementItemAmount(_cartItems[productInCart].Key);
                return;
            }
            AddItem(itemInProductCatalog);
        }

        private void AddItem(Product product)
        {
            var Item = new CartItem
            (
                product.Key,
                product.Title,
                product.Price,
                product.Id
            );
            Item.IncrementAmount();
            _cartItems.Add(Item);
            Console.WriteLine("\nТовар добавлен!\n");
        }

        public void DelInCart(Guid findKey)
        {
            if (findKey.Equals(Guid.Empty))
            {
                Console.WriteLine("Вы ничего не ввели.");
                return;
            }

            var item = TryGetItemIndex(findKey);
            if (item == -1)
            {
                Console.WriteLine("\nТовар не найден\n");
                return;
            }
            _cartItems.Remove(_cartItems[item]);
            Console.WriteLine("\nТовар удален\n");
        }

        public int TryGetItemIndex(Guid findKey, string findId = "")
        {
            foreach (var cardItem in _cartItems)
            {
                if (findKey == cardItem.Key || findId == cardItem.Id)
                {
                    return _cartItems.IndexOf(cardItem);
                }
            }
            return -1;
        }

        public void ShowCart()
        {
            if (_cartItems.Count() == 0)
            {
                Console.WriteLine("\nВ корзине нет товаров.");
                return;
            }
            foreach (var item in _cartItems)
                item.ShowCartItem();
            Console.WriteLine
                (
                    $"-------------------------------------------" +
                    $"\nКоличество товаров в корзине: " + TotalAmount +
                    $"\nОбщая стоимость: " + TotalCost + "\n"
                );
        }

        public void IncrementItemAmount(Guid findKey)
        {
            if (findKey == default)
            {
                Console.WriteLine("Вы ничего не ввели.");
                return;
            }

            foreach (var product in _cartItems)
            {
                if (findKey == product.Key)
                {
                    product.IncrementAmount();
                    Console.WriteLine("Товар добавлен");
                    return;
                }
            }
        }

        public void ClearCart()
        {
            _cartItems.Clear();
        }
    }
}
