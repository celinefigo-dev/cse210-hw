using System;

class Program
{
    static void Main()
    
    {
        Address address1 = new Address("123 Green St", "New York", "NY", "USA");
        Address address2 = new Address("456 Ocean Ave", "London", "England", "UK");

        Customer customer1 = new Customer("John Doe", address1);
        Customer customer2 = new Customer("Jane Smith", address2);

        Order order1 = new Order(customer1);
        order1.AddProduct(new Product("Laptop", "LAP123", 1200, 1));
        order1.AddProduct(new Product("Mouse", "MSE456", 25, 2));

        Order order2 = new Order(customer2);
        order2.AddProduct(new Product("Phone", "PHN789", 800, 1));
        order2.AddProduct(new Product("Charger", "CHR012", 30, 1));

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost()}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost()}");
    }
}