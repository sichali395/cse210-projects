public class Product
{
    // Private member variables
    private string _name;
    private string _productId;
    private decimal _price;
    private int _quantity;

    // Constructor
    public Product(string name, string productId, decimal price, int quantity)
    {
        _name = name;
        _productId = productId;
        _price = price;
        _quantity = quantity;
    }

    // Public getters
    public string GetName() => _name;
    public string GetProductId() => _productId;
    public decimal GetPrice() => _price;
    public int GetQuantity() => _quantity;

    // Method to calculate total cost for this product
    public decimal CalculateTotalCost()
    {
        return _price * _quantity;
    }
}