public class Address
{
    // Private member variables
    private string _streetAddress;
    private string _city;
    private string _stateProvince;
    private string _country;

    // Constructor
    public Address(string streetAddress, string city, string stateProvince, string country)
    {
        _streetAddress = streetAddress;
        _city = city;
        _stateProvince = stateProvince;
        _country = country;
    }

    // Public getters
    public string GetStreetAddress() => _streetAddress;
    public string GetCity() => _city;
    public string GetStateProvince() => _stateProvince;
    public string GetCountry() => _country;

    // Method to check if address is in USA
    public bool IsInUSA()
    {
        return _country.ToLower() == "usa";
    }

    // Method to return full address as string
    public string GetFullAddress()
    {
        return $"{_streetAddress}\n{_city}, {_stateProvince}\n{_country}";
    }
}