public class Fraction
{
    private int _top;
    private int _bottom;

    // Constructor with no parameters - initializes to 1/1
    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }

    // Constructor with one parameter for top - initializes denominator to 1
    public Fraction(int top)
    {
        _top = top;
        _bottom = 1;
    }

    // Constructor with two parameters - one for top, one for bottom
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }

    // Getter and Setter for top value
    public int Top
    {
        get { return _top; }
        set { _top = value; }
    }

    // Getter and Setter for bottom value
    public int Bottom
    {
        get { return _bottom; }
        set { _bottom = value; }
    }

    // Method to get fraction representation as string (e.g., "3/4")
    public string GetFractionString()
    {
        return $"{_top}/{_bottom}";
    }

    // Method to get decimal value (e.g., 0.75)
    public double GetDecimalValue()
    {
        return (double)_top / _bottom;
    }
}