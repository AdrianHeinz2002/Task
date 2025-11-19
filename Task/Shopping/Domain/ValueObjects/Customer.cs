namespace Task.Shopping.Domain.DTO
{
    public class Customer
    {
        public string Name { get; }
        public ShoppingBasket ShoppingBasket { get; }

        public List<Item> ShoppingList { get; }

        private Customer(string name, ShoppingBasket shoppingBasket, List<Item> shoppingList)
        {
            this.Name = name;
            this.ShoppingBasket = shoppingBasket;
            this.ShoppingList = shoppingList;
        }

        public static Customer Create(string name, ShoppingBasket shoppingBasket, List<Item> shoppingList)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("CustomerDTO - Create - invalid name");
            if (shoppingBasket == null) throw new ArgumentNullException("CustomerDTO - Create - invalid shoppingBasket");
            if (shoppingList == null) throw new ArgumentNullException("CustomerDTO - Create - invalid shoppingList");
            return new Customer(name,shoppingBasket,shoppingList);
        }
    }
}
