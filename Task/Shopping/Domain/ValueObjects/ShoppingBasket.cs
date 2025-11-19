using System;
using System.Collections.ObjectModel;
using Task.Shopping.Domain.Exceptions;

namespace Task.Shopping.Domain.DTO
{
    public class ShoppingBasket
    {
        public readonly static double MAX_WEIGHT_IN_KG = 20;
        private List<Item> _items;
        public ReadOnlyCollection<Item> Items => _items.AsReadOnly();

        private ShoppingBasket(List<Item> items)
        {
            this._items = items;
        }

        public static ShoppingBasket Create(List<Item> items)
        {
            List<Item> sortedItems = items.OrderByDescending(item => item.Weight).ToList();
            ValidateShoppingCart(items);
            return new ShoppingBasket(sortedItems);
        }

        public void AddItems(List<Item> items)
        {
            List<Item> sortedItems = this._items;
            sortedItems.AddRange(items);
            sortedItems = sortedItems.OrderByDescending(item => item.Weight).ToList();
            ValidateShoppingCart(sortedItems);
            this._items = sortedItems;
        }

        public void UpdateItems(List<Item> items)
        {
            this._items.Clear();
            List<Item> sortedItems = items.OrderByDescending(item => item.Weight).ToList();
            this._items.AddRange(sortedItems);
            ValidateShoppingCart(sortedItems);
            this._items = sortedItems;
        }

        private static void ValidateShoppingCart(List<Item> items)
        {
            double weight = 0;
            items.ForEach(i => weight += i.Weight);
            if (weight > MAX_WEIGHT_IN_KG) throw new TooMuchWeightException("ShoppingBasketDTO - Create - shoppingbasket is too heavy!");

        }
    }
}
