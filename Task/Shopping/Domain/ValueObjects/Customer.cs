namespace Task.Shopping.Domain.DTO
{
    public class Customer
    {
        public string Name { get; }
        public ShoppingBasket ShoppingBasket { get; }

        private Customer(string name, ShoppingBasket shoppingBasket)
        {
            this.Name = name;
            this.ShoppingBasket = shoppingBasket;
        }

        public static Customer Create(string name, ShoppingBasket shoppingBasket)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException("CustomerDTO - Create - invalid name");
            if (shoppingBasket == null) throw new ArgumentNullException("CustomerDTO - Create - invalid shoppingBasket");

            return new Customer(name,shoppingBasket);
        }
    }
}
