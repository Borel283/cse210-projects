using System;
using System.Collections.Generic;

class Address
{
    private string Street { get; set; }
    private string City { get; set; }
    private string State { get; set; }
    private string Country { get; set; }

    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public bool IsInUSA()
    {
        return Country.ToLower() == "usa";
    }

    public string GetFullAddress()
    {
        return $"{Street}\n{City}, {State}\n{Country}";
    }
}

class Customer
{
    private string Name { get; set; }
    private Address Address { get; set; }

    public Customer(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    public bool LivesInUSA()
    {
        return Address.IsInUSA();
    }

    public string GetName()
    {
        return Name;
    }

    public string GetAddress()
    {
        return Address.GetFullAddress();
    }
}

class Product
{
    private string Name { get; set; }
    private string ProductID { get; set; }
    private double Price { get; set; }
    private int Quantity { get; set; }

    public Product(string name, string productID, double price, int quantity)
    {
        Name = name;
        ProductID = productID;
        Price = price;
        Quantity = quantity;
    }

    public double GetTotalCost()
    {
        return Price * Quantity;
    }

    public string GetName()
    {
        return Name;
    }

    public string GetProductID()
    {
        return ProductID;
    }
}

class Order
{
    private Customer Customer { get; set; }
    private List<Product> Products { get; set; }

    public Order(Customer customer)
    {
        Customer = customer;
        Products = new List<Product>();
    }

    public void AddProduct(Product product)
    {
        Products.Add(product);
    }

    public double GetTotalCost()
    {
        double totalCost = 0;
        foreach (var product in Products)
        {
            totalCost += product.GetTotalCost();
        }
        double shippingCost = Customer.LivesInUSA() ? 5 : 35;
        return totalCost + shippingCost;
    }

    public string GetPackingLabel()
    {
        string label = "Packing Label:\n";
        foreach (var product in Products)
        {
            label += $"{product.GetName()} (ID: {product.GetProductID()})\n";
        }
        return label;
    }

    public string GetShippingLabel()
    {
        return $"Shipping Label:\n{Customer.GetName()}\n{Customer.GetAddress()}";
    }
}

class Program
{
    static void Main()
    {
        // Create some addresses
        Address address1 = new Address("123 Salt Lake City", "Salt Lake", "NY", "USA");
        Address address2 = new Address("456 Maple Ave", "Toronto", "ON", "Canada");

        // Create some customers
        Customer customer1 = new Customer("Adji Assi", address1);
        Customer customer2 = new Customer("Segbedi Pricile", address2);

        // Create some products
        Product product1 = new Product("Coca Cola", "W123", 10.0, 3);
        Product product2 = new Product("KFC", "G456", 15.0, 2);
        Product product3 = new Product("Hot dog", "H789", 7.5, 4);
        

        // Create some orders and add products to them
        Order order1 = new Order(customer1);
        order1.AddProduct(product1);
        order1.AddProduct(product2);

        Order order2 = new Order(customer2);
        order2.AddProduct(product2);
        order2.AddProduct(product3);

        // Print packing labels, shipping labels, and total cost for each order
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order1.GetTotalCost():0.00}\n");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"Total Cost: ${order2.GetTotalCost():0.00}\n");
    }
}
