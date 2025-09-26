using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Online Ordering System");
        Console.WriteLine("======================\n");

        // Create addresses
        Address address1 = new Address("123 Main St", "New York", "NY", "USA");
        Address address2 = new Address("456 Oak Ave", "Toronto", "ON", "Canada");
        Address address3 = new Address("789 Pine Rd", "Los Angeles", "CA", "USA");

        // Create customers
        Customer customer1 = new Customer("John Smith", address1);
        Customer customer2 = new Customer("Marie Curie", address2);
        Customer customer3 = new Customer("Bob Johnson", address3);

        // Create products
        Product product1 = new Product("Laptop", "P001", 999.99m, 1);
        Product product2 = new Product("Mouse", "P002", 25.50m, 2);
        Product product3 = new Product("Keyboard", "P003", 75.00m, 1);
        Product product4 = new Product("Monitor", "P004", 299.99m, 2);
        Product product5 = new Product("Webcam", "P005", 45.75m, 1);
        Product product6 = new Product("Headphones", "P006", 89.99m, 3);

        // Create orders
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        Order order2 = new Order(customer2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        Order order3 = new Order(customer3);
        order3.AddProduct(product1);
        order3.AddProduct(product6);
        order3.AddProduct(product2);

        // Display order information
        DisplayOrder(order1, 1);
        DisplayOrder(order2, 2);
        DisplayOrder(order3, 3);
    }

    static void DisplayOrder(Order order, int orderNumber)
    {
        Console.WriteLine($"ORDER #{orderNumber}");
        Console.WriteLine("============");
        
        Console.WriteLine("\nPACKING LABEL:");
        Console.WriteLine("--------------");
        Console.WriteLine(order.GetPackingLabel());
        
        Console.WriteLine("\nSHIPPING LABEL:");
        Console.WriteLine("---------------");
        Console.WriteLine(order.GetShippingLabel());
        
        Console.WriteLine("\nORDER TOTAL:");
        Console.WriteLine("------------");
        Console.WriteLine($"Total Cost: ${order.CalculateTotalCost():F2}");
        Console.WriteLine("\n" + new string('=', 50) + "\n");
    }
}