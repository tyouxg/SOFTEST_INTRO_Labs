using System.Globalization;
using SOFTEST_INTRO_Calculator;

var calculator = new Calculator();

Console.WriteLine("Calculator operations:");
Console.WriteLine("a=add, s=subtract, m=multiply, d=divide");
Console.WriteLine("f=factorial, t=triangle area, c=circle area");
Console.Write("Operation: ");

string op = (Console.ReadLine() ?? "").Trim().ToLowerInvariant();

if (op == "f"){
    RunFactorial();
    }

else if (op == "t"){
    RunTriangleArea();
    }
else if (op == "c"){
    RunCircleArea();
    }

else{
    RunBasicOperation(op);
    }

void RunBasicOperation(string operation)
{
    Console.Write("First number: ");
    string first = Console.ReadLine() ?? "";
    Console.Write("Second number: ");
    string second = Console.ReadLine() ?? "";

    bool firstOk = double.TryParse(
        first,
        NumberStyles.Float,
        CultureInfo.InvariantCulture,
        out double a);

    bool secondOk = double.TryParse(
        second,
        NumberStyles.Float,
        CultureInfo.InvariantCulture,
        out double b);

    if (!firstOk || !secondOk ||
        !double.IsFinite(a) || !double.IsFinite(b))
    {
        Console.WriteLine("Enter finite numbers; use . for decimals.");
        return;
    }

    try
    {
        double result = calculator.DoOperation(a, b, operation);
        string text = result.ToString(CultureInfo.InvariantCulture);
        Console.WriteLine("Result: " + text);
    }
    catch (ArgumentException error)
    {
        Console.WriteLine(error.Message);
    }
}

void RunFactorial()
{
    Console.Write("Enter a whole number (0-20): ");
    string input = Console.ReadLine() ?? "";

    if (!TryParseWholeNumber(input, out int n))
    {
        Console.WriteLine("Enter a whole number; fractional values are not accepted.");
        return;
    }

    try
    {
        long result = calculator.Factorial(n);
        Console.WriteLine("Result: " + result);
    }
    catch (ArgumentOutOfRangeException error)
    {
        Console.WriteLine(error.Message);
    }
}

void RunTriangleArea()
{
    Console.Write("Height: ");
    string heightInput = Console.ReadLine() ?? "";
    Console.Write("Width: ");
    string widthInput = Console.ReadLine() ?? "";

    bool heightOk = double.TryParse(
        heightInput, NumberStyles.Float, CultureInfo.InvariantCulture, out double height);
    bool widthOk = double.TryParse(
        widthInput, NumberStyles.Float, CultureInfo.InvariantCulture, out double width);

    if (!heightOk || !widthOk || !double.IsFinite(height) || !double.IsFinite(width))
    {
        Console.WriteLine("Enter finite numbers; use . for decimals.");
        return;
    }

    try
    {
        double result = calculator.TriangleArea(height, width);
        Console.WriteLine("Result: " + result.ToString(CultureInfo.InvariantCulture));
    }
    catch (ArgumentOutOfRangeException error)
    {
        Console.WriteLine(error.Message);
    }
}

void RunCircleArea()
{
    Console.Write("Radius: ");
    string radiusInput = Console.ReadLine() ?? "";

    bool radiusOk = double.TryParse(
        radiusInput, NumberStyles.Float, CultureInfo.InvariantCulture, out double radius);

    if (!radiusOk || !double.IsFinite(radius))
    {
        Console.WriteLine("Enter a finite number; use . for decimals.");
        return;
    }

    try
    {
        double result = calculator.CircleArea(radius);
        Console.WriteLine("Result: " + result.ToString(CultureInfo.InvariantCulture));
    }
    catch (ArgumentOutOfRangeException error)
    {
        Console.WriteLine(error.Message);
    }
}



bool TryParseWholeNumber(string input, out int value)
{
    value = 0;
    bool ok = double.TryParse(
        input, NumberStyles.Float, CultureInfo.InvariantCulture, out double parsed);

    if (!ok || !double.IsFinite(parsed) || parsed != Math.Truncate(parsed))
    {
        return false;
    }

    value = (int)parsed;
    return true;
}