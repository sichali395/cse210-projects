using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Test individual classes
        Console.WriteLine("Testing Individual Shapes:");
        Console.WriteLine("==========================");
        
        Square square = new Square("Red", 5);
        Console.WriteLine($"Square - Color: {square.Color}, Area: {square.GetArea()}");
        
        Rectangle rectangle = new Rectangle("Blue", 4, 6);
        Console.WriteLine($"Rectangle - Color: {rectangle.Color}, Area: {rectangle.GetArea()}");
        
        Circle circle = new Circle("Green", 3);
        Console.WriteLine($"Circle - Color: {circle.Color}, Area: {circle.GetArea():F2}");
        
        Console.WriteLine("\n" + new string('=', 40));
        Console.WriteLine("Testing with List of Shapes:");
        Console.WriteLine("============================");
        
        // Create a list to hold shapes
        List<Shape> shapes = new List<Shape>();
        
        // Add different shapes to the list
        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 4, 6));
        shapes.Add(new Circle("Green", 3));
        shapes.Add(new Square("Yellow", 7));
        shapes.Add(new Rectangle("Purple", 3, 8));
        shapes.Add(new Circle("Orange", 4.5));
        
        // Iterate through the list and display color and area for each shape
        foreach (Shape shape in shapes)
        {
            string shapeType = shape.GetType().Name;
            double area = shape.GetArea();
            
            // Format area based on shape type (circles might have many decimal places)
            if (shape is Circle)
            {
                Console.WriteLine($"{shapeType} - Color: {shape.Color}, Area: {area:F2}");
            }
            else
            {
                Console.WriteLine($"{shapeType} - Color: {shape.Color}, Area: {area}");
            }
        }
    }
}