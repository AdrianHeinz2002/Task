using Task.Shopping.Domain.DTO;
using Task.Shopping.Domain.Exceptions;

namespace TaskTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void shoppingBasket_TooMuchWeight_Exception_True()
        {
            // ARRANGE
            Item item1 = Item.Create("Apple", "fruit", 1);
            Item item2 = Item.Create("Banana", "fruit", 1);
            Item item3 = Item.Create("Orange", "fruit", 1);
            Item item4 = Item.Create("Watermelon", "fruit", 5);
            Item item5 = Item.Create("Pumpkin", "vegetable", 7);
            Item item6 = Item.Create("Macbook", "super computer", 6);
            List<Item> items = new List<Item> { item1, item2, item3, item4, item5, item6 };

            // ACT

            // ASSERT
            Assert.Throws<TooMuchWeightException>(() => ShoppingBasket.Create(items));
        }

        [Test]
        public void shoppingBasket_OrderedByWeightAscending_True()
        {
            // ARRANGE
            Item item1 = Item.Create("Macbook", "super computer", 6);
            Item item2 = Item.Create("Banana", "fruit", 1);
            Item item3 = Item.Create("Pumpkin", "vegetable", 7);
            Item item4 = Item.Create("Watermelon", "fruit", 3);
            Item item5 = Item.Create("Orange", "fruit", 2);
            List<Item> items = new List<Item> { item1, item2, item3, item4, item5 };

            ShoppingBasket shoppingBasket = ShoppingBasket.Create(items);
            Customer customer = Customer.Create("Michael Clausen", shoppingBasket);

            // ACT

            // ASSERT
            Assert.True(shoppingBasket.Items[0].Name.Equals("Pumpkin"));
            Assert.True(shoppingBasket.Items[1].Name.Equals("Macbook"));
            Assert.True(shoppingBasket.Items[2].Name.Equals("Watermelon"));
            Assert.True(shoppingBasket.Items[3].Name.Equals("Orange"));
            Assert.True(shoppingBasket.Items[4].Name.Equals("Banana"));
        }

        [Test]
        public void shoppingBasket_correctWeight_Exception_False()
        {
            // ARRANGE
            Item item1 = Item.Create("Apple", "fruit", 1);       
            Item item2 = Item.Create("Banana", "fruit", 1);      
            Item item3 = Item.Create("Orange", "fruit", 1);      
            Item item4 = Item.Create("Watermelon", "fruit", 5);  
            Item item5 = Item.Create("Pumpkin", "vegetable", 7);
            List<Item> items = new List<Item> { item1, item2, item3, item4, item5 };

            ShoppingBasket shoppingBasket = ShoppingBasket.Create(items);
            Customer customer = Customer.Create("Michael Clausen", shoppingBasket);

            // ACT

            // ASSERT
            Assert.Pass();
        }
    }
}