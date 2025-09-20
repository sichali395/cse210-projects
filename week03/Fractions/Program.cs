using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Testing Fraction Constructors");
        Console.WriteLine("=============================");
        Console.WriteLine();

        // Test first constructor (no parameters) - should be 1/1
        Fraction fraction1 = new Fraction();
        Console.WriteLine($"Constructor 1: {fraction1.GetFractionString()}");

        // Test second constructor (one parameter) - should be 5/1
        Fraction fraction2 = new Fraction(5);
        Console.WriteLine($"Constructor 2: {fraction2.GetFractionString()}");

        // Test third constructor (two parameters) - should be 3/4
        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine($"Constructor 3: {fraction3.GetFractionString()}");

        Console.WriteLine();
        Console.WriteLine("Decimal Values:");
        Console.WriteLine($"1/1 = {fraction1.GetDecimalValue()}");
        Console.WriteLine($"5/1 = {fraction2.GetDecimalValue()}");
        Console.WriteLine($"3/4 = {fraction3.GetDecimalValue()}");

        // Additional examples mentioned in the requirements
        Console.WriteLine();
        Console.WriteLine("Additional Examples:");
        
        Fraction fraction4 = new Fraction();        // 1/1 (first constructor)
        Fraction fraction5 = new Fraction(6);       // 6/1 (second constructor)
        Fraction fraction6 = new Fraction(6, 7);    // 6/7 (third constructor)

        Console.WriteLine($"1/1 = {fraction4.GetFractionString()}");
        Console.WriteLine($"6/1 = {fraction5.GetFractionString()}");
        Console.WriteLine($"6/7 = {fraction6.GetFractionString()}");

        Console.WriteLine();
        Console.WriteLine("Testing Getters and Setters");
        Console.WriteLine("===========================");
        Console.WriteLine();

        // Test getters
        Console.WriteLine("Initial values using getters:");
        Console.WriteLine($"Fraction 1 - Top: {fraction1.Top}, Bottom: {fraction1.Bottom}");
        Console.WriteLine($"Fraction 2 - Top: {fraction2.Top}, Bottom: {fraction2.Bottom}");
        Console.WriteLine($"Fraction 3 - Top: {fraction3.Top}, Bottom: {fraction3.Bottom}");

        // Test setters to change values
        Console.WriteLine();
        Console.WriteLine("Changing values using setters...");
        
        fraction1.Top = 7;          // Change from 1 to 7
        fraction1.Bottom = 8;        // Change from 1 to 8
        
        fraction2.Top = 9;           // Change from 5 to 9
        fraction2.Bottom = 2;        // Change from 1 to 2
        
        fraction3.Top = 10;          // Change from 3 to 10
        fraction3.Bottom = 11;       // Change from 4 to 11

        // Verify changes using getters
        Console.WriteLine();
        Console.WriteLine("Updated values using getters:");
        Console.WriteLine($"Fraction 1 - Top: {fraction1.Top}, Bottom: {fraction1.Bottom}");
        Console.WriteLine($"Fraction 2 - Top: {fraction2.Top}, Bottom: {fraction2.Bottom}");
        Console.WriteLine($"Fraction 3 - Top: {fraction3.Top}, Bottom: {fraction3.Bottom}");

        // Show the updated fractions
        Console.WriteLine();
        Console.WriteLine("Updated fractions:");
        Console.WriteLine($"Fraction 1: {fraction1.GetFractionString()} = {fraction1.GetDecimalValue():F3}");
        Console.WriteLine($"Fraction 2: {fraction2.GetFractionString()} = {fraction2.GetDecimalValue():F3}");
        Console.WriteLine($"Fraction 3: {fraction3.GetFractionString()} = {fraction3.GetDecimalValue():F3}");

        // Additional getter/setter tests
        Console.WriteLine();
        Console.WriteLine("Additional Getter/Setter Tests:");
        Console.WriteLine("===============================");
        
        Fraction testFraction = new Fraction(2, 3);
        Console.WriteLine($"Initial: {testFraction.GetFractionString()}");
        
        // Use getter to retrieve values
        int currentTop = testFraction.Top;
        int currentBottom = testFraction.Bottom;
        Console.WriteLine($"Retrieved values - Top: {currentTop}, Bottom: {currentBottom}");
        
        // Use setters to modify values
        testFraction.Top = currentTop * 2;      // Double the numerator
        testFraction.Bottom = currentBottom * 3; // Triple the denominator
        
        Console.WriteLine($"After modification: {testFraction.GetFractionString()}");
        Console.WriteLine($"Decimal value: {testFraction.GetDecimalValue():F3}");

        // =================================================================
        // NEW CODE: Testing specific fractions as requested (1, 5, 3/4, 1/3)
        // =================================================================
        Console.WriteLine();
        Console.WriteLine("Testing Specific Fractions as Requested");
        Console.WriteLine("========================================");
        Console.WriteLine();

        // Create the specific fractions mentioned: 1, 5, 3/4, 1/3
        Fraction f1 = new Fraction(1);      // 1/1 (represents the number 1)
        Fraction f2 = new Fraction(5);      // 5/1 (represents the number 5)
        Fraction f3 = new Fraction(3, 4);   // 3/4
        Fraction f4 = new Fraction(1, 3);   // 1/3

        // Display both representations for each fraction
        Console.WriteLine("Fraction representations:");
        Console.WriteLine("-------------------------");
        Console.WriteLine($"{f1.GetFractionString()} = {f1.GetDecimalValue()}");
        Console.WriteLine($"{f2.GetFractionString()} = {f2.GetDecimalValue()}");
        Console.WriteLine($"{f3.GetFractionString()} = {f3.GetDecimalValue():F3}");
        Console.WriteLine($"{f4.GetFractionString()} = {f4.GetDecimalValue():F3}");

        // Additional verification with more examples
        Console.WriteLine();
        Console.WriteLine("Additional Verification Examples:");
        Console.WriteLine("---------------------------------");
        
        // Test edge cases and various fractions
        Fraction[] testFractions = {
            new Fraction(),         // 1/1
            new Fraction(0),        // 0/1
            new Fraction(2, 1),     // 2/1
            new Fraction(1, 2),     // 1/2
            new Fraction(2, 3),     // 2/3
            new Fraction(3, 2),     // 3/2 (improper fraction)
            new Fraction(5, 10)     // 5/10 (should simplify to 0.5)
        };

        foreach (var frac in testFractions)
        {
            Console.WriteLine($"{frac.GetFractionString()} = {frac.GetDecimalValue():F3}");
        }
    }
}