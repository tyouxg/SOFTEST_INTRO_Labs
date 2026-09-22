namespace SOFTEST_INTRO_Calculator;
public class Calculator
{

 public double Subtract(double a, double b) => a - b;
 public double Multiply(double a, double b) => a * b;
 // Starter version: complete the zero-divisor rule in section 5.
 public double Add(double a, double b)
 {
     if (IsBinaryNumber(a) && IsBinaryNumber(b))
     {
         long binA = Convert.ToInt64(((long)a).ToString(), 2);
         long binB = Convert.ToInt64(((long)b).ToString(), 2);
         return (binA * binB) + binA + binB;
     }
     return a + b;
} // 

private static bool IsBinaryNumber(double value)
{
    if (value < 0 || value != Math.Floor(value))
    {
        return false;
    }
    string digits = ((long)value).ToString();
    foreach (char c in digits)
    {
        if (c != '0' && c != '1')
        {
            return false;
        }
    }
    return true;
}

public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Cannot divide by zero.");
        }
        return a / b;
    }
    public double DoOperation(double a, double b, string op)
    {
    return op switch
    {
        "a" => Add(a, b),
        "s" => Subtract(a, b),
        "m" => Multiply(a, b),
        "d" => Divide(a, b),

        _ => throw new ArgumentException("Unknown operation.")
    };
    }
    public long Factorial(int n)
    {
    if (n < 0 || n > 20)
        {
        throw new ArgumentOutOfRangeException(nameof(n), "n must be between 0 and 20.");
        }

    long result = 1;
    for (int i = 2; i <= n; i++)
        {
        result *= i;
        }
    return result;
    }

    public double TriangleArea(double height, double width)
    {
    if (height < 0 || width < 0)
    {
        throw new ArgumentOutOfRangeException("Height and width must not be negative.");
    }
    return height * width / 2;
    }

    public double CircleArea(double radius)
    {
    if (radius < 0)
        {
        throw new ArgumentOutOfRangeException(nameof(radius), "Radius must not be negative.");
        }
    return Math.PI * radius * radius;
    }

    public long UnknownFunctionA(int n, int r)
    {
        if (n < 0 || n > 20 || r < 0 || r > n)
        {
            throw new ArgumentOutOfRangeException("n and r must satisfy 0 <= r <= n <= 20.");
        }
        return Factorial(n) / Factorial(n - r);
    }
    public long UnknownFunctionB(int n, int r)
    {
        if (n < 0 || n > 20 || r < 0 || r > n)
        {
            throw new ArgumentOutOfRangeException("n and r must satisfy 0 <= r <= n <= 20.");
        }
        return Factorial(n) / (Factorial(r) * Factorial(n - r));
    }

    public double Mtbf(double operatingTime, double failureCount)
    {
        if (operatingTime <= 0 || failureCount <= 0)
            throw new ArgumentException("Operating time and failure count must be positive.");

        return operatingTime / failureCount;
    }

    public double Availability(double mtbf, double mttr)
    {
        if (mtbf < 0 || mttr < 0)
            throw new ArgumentException("MTBF and MTTR cannot be negative.");

        double denominator = mtbf + mttr;
        if (denominator <= 0)
            throw new ArgumentException("The denominator (MTBF + MTTR) must be positive.");

        return mtbf / denominator;
    }


        public double CurrentFailureIntensity(double lambda0, double nu0, double tau)
    {
        ValidateBasicMusaInputs(lambda0, nu0, tau);
        return lambda0 * Math.Exp(-lambda0 * tau / nu0);
    }

    public double ExpectedCumulativeFailures(double lambda0, double nu0, double tau)
    {
        ValidateBasicMusaInputs(lambda0, nu0, tau);
        return nu0 * (1 - Math.Exp(-lambda0 * tau / nu0));
    }

    private static void ValidateBasicMusaInputs(double lambda0, double nu0, double tau)
    {
        if (lambda0 <= 0)
            throw new ArgumentException("lambda0 (initial failure intensity) must be positive.");
        if (nu0 <= 0)
            throw new ArgumentException("nu0 (expected total failures) must be positive.");
        if (tau < 0)
            throw new ArgumentException("tau (execution time) cannot be negative.");
    }

    public double GenMagicNum(
        
        int choice, string path, IFileReader fileReader)
        {
            ArgumentNullException.ThrowIfNull(fileReader);
        if (choice < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(choice));
        }
            string[] magicStrings = fileReader.Read(path);
        if (choice >= magicStrings.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(choice));
        }
            double magicNumber = double.Parse(magicStrings[choice]);
            return 2 * Math.Abs(magicNumber);
        }




}


