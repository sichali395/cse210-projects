public class Shape
{
    private string _color;
    
    // Getter and Setter for color
    public string Color
    {
        get { return _color; }
        set { _color = value; }
    }
    
    // Constructor
    public Shape(string color)
    {
        _color = color;
    }
    
    // Virtual method for GetArea - can be overridden by derived classes
    public virtual double GetArea()
    {
        // Base implementation returns 0
        // Derived classes will override this with their specific implementations
        return 0;
    }
}