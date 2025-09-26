public class Customer
{
    // Private member variables
    private string _name;
    private Address _address;

    // Constructor
    public Customer(string name, Address address)
    {
        _name = name;
        _address = address;
    }

    // Public getters
    public string GetName() => _name;
    public Address GetAddress() => _address;

    // Method to check if customer lives in USA
    public bool LivesInUSA()
    {
        return _address.IsInUSA();
    }
}