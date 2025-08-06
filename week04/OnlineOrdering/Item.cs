namespace OnlineOrderingProgram.Models
{
    public class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Item(string name, double price, int quantity)
        {
            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public double GetTotalPrice()
        {
            return Price * Quantity;
        }

        public void DisplayItem()
        {
            Console.WriteLine($"{Name} - {Quantity} x ${Price:F2} = ${GetTotalPrice():F2}");
        }
    }
}