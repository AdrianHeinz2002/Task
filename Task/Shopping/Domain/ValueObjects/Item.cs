namespace Task.Shopping.Domain.DTO
{
    public class Item
    {
        public string Name { get; }
        public string Description { get; }
        public double Weight { get; }

        private Item(string name, string description, double weight)
        {
            this.Name = name;
            this.Description = description;
            this.Weight = weight;
        }

        public static Item Create(string name, string description, double weight)
        {
            if(string.IsNullOrEmpty(name)) throw new ArgumentNullException("ItemDTO - Create - invalid name");
            if (string.IsNullOrEmpty(description)) throw new ArgumentNullException("ItemDTO - Create - invalid description");
            if (weight <= 0) throw new ArgumentException("ItemDTO - Create - invalid weight");

            return new Item(name, description, weight);
        }
    }
}
