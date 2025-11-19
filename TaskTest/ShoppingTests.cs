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

        // CREATE
        [Test]
        public void ShoppingBasket_Create_TooMuchWeight_Throws_TooMuchWeightException()
        {
            // ARRANGE
            List<Item> items = CreateItems();

            // ACT
            items.Add(Item.Create("Macbook", "superpc", 6));

            // ASSERT
            Assert.Throws<TooMuchWeightException>(() => ShoppingBasket.Create(items));
        }
        [Test]
        public void ShoppingBasket_Create_correctWeight_Throws_NoException()
        {
            // ARRANGE
            List<Item> items = CreateItems();

            // ACT
            ShoppingBasket shoppingBasket = ShoppingBasket.Create(items);

            // ASSERT
            Assert.Pass();
        }

        [Test]
        public void ShoppingBasket_Create_OrderedByWeightDescending_True()
        {
            // ARRANGE
            List<Item> items = CreateItems();

            // ACT
            ShoppingBasket shoppingBasket = ShoppingBasket.Create(items);

            // ASSERT
            Assert.True(shoppingBasket.Items[0].Name.Equals("Pumpkin"));
            Assert.True(shoppingBasket.Items[1].Name.Equals("Watermelon"));
            Assert.True(shoppingBasket.Items[2].Name.Equals("Banana"));
            Assert.True(shoppingBasket.Items[3].Name.Equals("Orange"));
            Assert.True(shoppingBasket.Items[4].Name.Equals("Apple"));
        }

        // ADDITEMS
        [Test]
        public void ShoppingBasket_AddItems_TooMuchWeight_Throws_TooMuchWeightException()
        {
            // ARRANGE
            List<Item> items = CreateItems();
            ShoppingBasket shoppingBasket = ShoppingBasket.Create(items);
            // ACT

            // ASSERT
            Assert.Throws<TooMuchWeightException>(() => shoppingBasket.AddItems(new List<Item> { Item.Create("Macbook", "superpc", 6) }));
        }

        [Test]
        public void ShoppingBasket_AddItems_correctWeight_Throws_NoException()
        {
            // ARRANGE
            List<Item> items = CreateItems();
            ShoppingBasket shoppingBasket = ShoppingBasket.Create(items);

            // ACT
            shoppingBasket.AddItems(new List<Item> { Item.Create("Macbook", "superpc", 1) });

            // ASSERT
            Assert.Pass();
        }

        [Test]
        public void ShoppingBasket_AddItems_OrderedByWeightDescending_True()
        {
            // ARRANGE
            List<Item> items = CreateItems();
            ShoppingBasket shoppingBasket = ShoppingBasket.Create(items);

            // ACT
            shoppingBasket.AddItems(new List<Item> { Item.Create("Macbook", "superpc", 5.5) });

            // ASSERT
            Assert.True(shoppingBasket.Items[0].Name.Equals("Macbook"));
            Assert.True(shoppingBasket.Items[1].Name.Equals("Pumpkin"));
            Assert.True(shoppingBasket.Items[2].Name.Equals("Watermelon"));
            Assert.True(shoppingBasket.Items[3].Name.Equals("Banana"));
            Assert.True(shoppingBasket.Items[4].Name.Equals("Orange"));
            Assert.True(shoppingBasket.Items[5].Name.Equals("Apple"));
        }


        // ADDITEMS
        [Test]
        public void ShoppingBasket_UpdateItems_TooMuchWeight_Throws_TooMuchWeightException()
        {
            // ARRANGE
            List<Item> items = CreateItems();
            ShoppingBasket shoppingBasket = ShoppingBasket.Create(items);

            Item item1 = Item.Create("Milk", "Breakfast", 0.5);         
            Item item2 = Item.Create("Rice Bag", "Breakfast", 3);      
            Item item3 = Item.Create("Cereal Box", "Breakfast", 2);
            Item item4 = Item.Create("Juice Carton", "Breakfast", 4);
            Item item5 = Item.Create("Flour Sack", "Breakfast", 5);
            Item item6 = Item.Create("Sack", "Breakfast", 6);

            List<Item> itemsNew = new List<Item> { item1, item2, item3, item4, item5, item6 };

            // ACT

            // ASSERT
            Assert.Throws<TooMuchWeightException>(() => shoppingBasket.UpdateItems(itemsNew));
        }

        [Test]
        public void ShoppingBasket_UpdateItems_correctWeight_Throws_NoException()
        {
            // ARRANGE
            List<Item> items = CreateItems();
            ShoppingBasket shoppingBasket = ShoppingBasket.Create(items);

            Item item1 = Item.Create("Milk", "Breakfast", 0.5);
            Item item2 = Item.Create("Rice Bag", "Breakfast", 3);
            Item item3 = Item.Create("Cereal Box", "Breakfast", 2);
            Item item4 = Item.Create("Juice Carton", "Breakfast", 4);
            Item item5 = Item.Create("Flour Sack", "Breakfast", 5);

            List<Item> itemsNew = new List<Item> { item1, item2, item3, item4, item5 };

            // ACT
            shoppingBasket.UpdateItems(itemsNew);

            // ASSERT
            Assert.Pass();
        }

        [Test]
        public void ShoppingBasket_UpdateItems_OrderedByWeightDescending_True()
        {
            // ARRANGE
            List<Item> items = CreateItems();
            ShoppingBasket shoppingBasket = ShoppingBasket.Create(items);

            Item item1 = Item.Create("Milk", "Breakfast", 0.5);
            Item item2 = Item.Create("Rice Bag", "Breakfast", 3);
            Item item3 = Item.Create("Cereal Box", "Breakfast", 2);
            Item item4 = Item.Create("Juice Carton", "Breakfast", 4);
            Item item5 = Item.Create("Flour Sack", "Breakfast", 5);

            List<Item> itemsNew = new List<Item> { item1, item2, item3, item4, item5 };

            // ACT
            shoppingBasket.UpdateItems(itemsNew);

            // ASSERT
            Assert.True(shoppingBasket.Items[0].Name.Equals("Flour Sack"));
            Assert.True(shoppingBasket.Items[1].Name.Equals("Juice Carton"));
            Assert.True(shoppingBasket.Items[2].Name.Equals("Rice Bag"));
            Assert.True(shoppingBasket.Items[3].Name.Equals("Cereal Box"));
            Assert.True(shoppingBasket.Items[4].Name.Equals("Milk"));
        }
        // CREATE
        [Test]
        public void Customer_Create_WorksCorrectly()
        {
            // ARRANGE
            List<Item> items = CreateItems();
            
            // ACT
            Customer customer = Customer.Create("Michael Clausen", ShoppingBasket.Create(new List<Item>()), items);
            customer.ShoppingBasket.AddItems(items);
            
            // ASSERT
            Assert.True(customer.ShoppingBasket.Items[0].Name.Equals("Pumpkin"));
            Assert.True(customer.ShoppingBasket.Items[1].Name.Equals("Watermelon"));
            Assert.True(customer.ShoppingBasket.Items[2].Name.Equals("Banana"));
            Assert.True(customer.ShoppingBasket.Items[3].Name.Equals("Orange"));
            Assert.True(customer.ShoppingBasket.Items[4].Name.Equals("Apple"));
        }


        private List<Item> CreateItems()
        {
            Item item1 = Item.Create("Apple", "fruit", 0.5);
            Item item2 = Item.Create("Banana", "fruit", 3);
            Item item3 = Item.Create("Orange", "fruit", 2);
            Item item4 = Item.Create("Watermelon", "fruit", 4);
            Item item5 = Item.Create("Pumpkin", "vegetable", 5);

            List<Item> items = new List<Item> { item1, item2, item3, item4, item5 };
            return items;
        }


    }
}