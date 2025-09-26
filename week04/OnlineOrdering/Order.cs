using System.Collections.Generic;

public class Order
{
    // Private member variables
    private List<Product> _products;
    private Customer _customer;

    // Constructor
    public Order(Customer customer)
    {
        _customer = customer;
        _products = new List<Product>();
    }

    // Method to add product to order
    public void AddProduct(Product product)
    {
        _products.Add(product);
    }

    // Method to calculate total cost
    public decimal CalculateTotalCost()
    {
        decimal totalCost = 0;
        
        // Calculate product costs
        foreach (Product product in _products)
        {
            totalCost += product.CalculateTotalCost();
        }

        // Add shipping cost
        decimal shippingCost = _customer.LivesInUSA() ? 5m : 35m;
        totalCost += shippingCost;

        return totalCost;
    }

    // Method to generate packing label
    public string GetPackingLabel()
    {
        string packingLabel = "";
        
        foreach (Product product in _products)
        {
            packingLabel += $"Product: {product.GetName()} (ID: {product.GetProductId()})\n";
        }

        return packingLabel;
    }

    // Method to generate shipping label
    public string GetShippingLabel()
    {
        return $"Customer: {_customer.GetName()}\nAddress:\n{_customer.GetAddress().GetFullAddress()}";
    }
}