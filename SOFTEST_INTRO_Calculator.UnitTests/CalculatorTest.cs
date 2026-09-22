using SOFTEST_INTRO_Calculator;
using NUnit.Framework;
namespace SOFTEST_INTRO_Calculator.UnitTests;
public class CalculatorTests
{
    private Calculator _calculator = null!;
    [SetUp]
    public void SetUp()
    {
       _calculator = new Calculator();
    }
    [Test]
    public void Add_TwoPositiveNumbers_ReturnsSum()
    {
        // Arrange: the calculator is created in SetUp.
        // Act
        double result = _calculator.Add(10, 20);
        // Assert
        Assert.That(result, Is.EqualTo(30));
    }


    [TestCase(0, 0, 0)]
    [TestCase(0, 5, 5)]
    [TestCase(-3, 8, 5)]
    [TestCase(0.1, 0.2, 0.3)]
    public void Add_RepresentativeInputs_ReturnsSum(
    double a, double b, double expected)
    {
        double result = _calculator.Add(a, b);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }


    [TestCase(15, 0)]
    [TestCase(0, 0)]
    public void Divide_ZeroDivisor_ThrowsArgumentException(double a, double b)
    {
        Assert.That(() => _calculator.Divide(a, b),
        Throws.TypeOf<ArgumentException>());
    }

    [TestCase(1, 2, 0.5)]
    [TestCase(0, 15, 0)]
    [TestCase(15, -3, -5)]
    public void Divide_RepresentativeInputs_ReturnsQuotient(
            double a, double b, double expected)
        {
            double result = _calculator.Divide(a, b);
            Assert.That(result, Is.EqualTo(expected).Within(1e-9));
        }


    [TestCase(10, 4, 6)]
    [TestCase(5, 0, 5)]
    [TestCase(0, 5, -5)]
    [TestCase(-3, -8, 5)]
    public void Subtract_RepresentativeInputs_ReturnsDifference(
        double a, double b, double expected)
    {
        double result = _calculator.Subtract(a, b);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(3, 4, 12)]
    [TestCase(5, 0, 0)]
    [TestCase(0, -7, 0)]
    [TestCase(-3, 4, -12)]
    [TestCase(-3, -4, 12)]
    public void Multiply_RepresentativeInputs_ReturnsProduct(
        double a, double b, double expected)
    {
        double result = _calculator.Multiply(a, b);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    [Test]
    public void Factorial_Zero_ReturnsOne()
    {
    long result = _calculator.Factorial(0);
    Assert.That(result, Is.EqualTo(1L));
    }

    [Test]
    [TestCase(3, 4, 6)]
    [TestCase(0, 4, 0)]
    [TestCase(3, 0, 0)]
    public void TriangleArea_RepresentativeInputs_ReturnsArea(
        double height, double width, double expected)
    {
        double result = _calculator.TriangleArea(height, width);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(-1, 4)]
    [TestCase(3, -1)]
    public void TriangleArea_NegativeDimension_ThrowsArgumentOutOfRangeException(
        double height, double width)
    {
        Assert.That(() => _calculator.TriangleArea(height, width),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [Test]
    [TestCase(1, Math.PI)]
    [TestCase(0, 0)]
    public void CircleArea_RepresentativeInputs_ReturnsArea(double radius, double expected)
    {
        double result = _calculator.CircleArea(radius);
        Assert.That(result, Is.EqualTo(expected).Within(1e-9));
    }

    [TestCase(-1)]
    public void CircleArea_NegativeRadius_ThrowsArgumentOutOfRangeException(double radius)
    {
        Assert.That(() => _calculator.CircleArea(radius),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    

    [TestCase(5, 5, 120L)]
    [TestCase(5, 4, 120L)]
    [TestCase(5, 3, 60L)]
    [TestCase(5, 0, 1L)]
    [TestCase(0, 0, 1L)]
    public void UnknownFunctionA_ValidInputs_ReturnsExpected(int n, int r, long expected)
    {
        long result = _calculator.UnknownFunctionA(n, r);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(5, 5, 1L)]
    [TestCase(5, 4, 5L)]
    [TestCase(5, 3, 10L)]
    [TestCase(5, 0, 1L)]
    [TestCase(0, 0, 1L)]
    public void UnknownFunctionB_ValidInputs_ReturnsExpected(int n, int r, long expected)
    {
        long result = _calculator.UnknownFunctionB(n, r);
        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(-4, 5)]
    [TestCase(4, 5)]
    public void UnknownFunctionA_InvalidInputs_ThrowsArgumentOutOfRangeException(int n, int r)
    {
        Assert.That(() => _calculator.UnknownFunctionA(n, r),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }

    [TestCase(-4, 5)]
    [TestCase(4, 5)]
    public void UnknownFunctionB_InvalidInputs_ThrowsArgumentOutOfRangeException(int n, int r)
    {
        Assert.That(() => _calculator.UnknownFunctionB(n, r),
            Throws.TypeOf<ArgumentOutOfRangeException>());
    }
    [Test]
    public void Mtbf_ValidInputs_ReturnsExpectedValue()
    {
        var calculator = new Calculator();
        Assert.That(calculator.Mtbf(900, 10), Is.EqualTo(90).Within(1e-9));
    }

    [Test]
    public void Mtbf_ZeroFailures_ThrowsArgumentException()
    {
        var calculator = new Calculator();
        Assert.Throws<ArgumentException>(() => calculator.Mtbf(900, 0));
    }

    [Test]
    public void Mtbf_NonPositiveOperatingTime_ThrowsArgumentException()
    {
        var calculator = new Calculator();
        Assert.Throws<ArgumentException>(() => calculator.Mtbf(-1, 10));
    }

    [Test]
    public void Availability_ValidInputs_ReturnsExpectedValue()
    {
        var calculator = new Calculator();
        Assert.That(calculator.Availability(90, 10), Is.EqualTo(0.9).Within(1e-9));
    }

    [Test]
    public void Availability_NegativeMttr_ThrowsArgumentException()
    {
        var calculator = new Calculator();
        Assert.Throws<ArgumentException>(() => calculator.Availability(90, -5));
    }

    [Test]
    public void Availability_ZeroDenominator_ThrowsArgumentException()
    {
        var calculator = new Calculator();
        Assert.Throws<ArgumentException>(() => calculator.Availability(0, 0));
    }

    [Test]
    public void CurrentFailureIntensity_AtStartOfExecution_EqualsLambda0()
    {
        var calculator = new Calculator();
        Assert.That(calculator.CurrentFailureIntensity(1, 10, 0), Is.EqualTo(1).Within(1e-9));
    }

    [Test]
    public void CurrentFailureIntensity_NormalExecutionTime_ReturnsExpectedValue()
    {
        var calculator = new Calculator();
        Assert.That(calculator.CurrentFailureIntensity(1, 10, 10), Is.EqualTo(Math.Exp(-1)).Within(1e-9));
    }

    [Test]
    public void CurrentFailureIntensity_ZeroLambda0_ThrowsArgumentException()
    {
        var calculator = new Calculator();
        Assert.Throws<ArgumentException>(() => calculator.CurrentFailureIntensity(0, 10, 5));
    }

    [Test]
    public void CurrentFailureIntensity_NegativeLambda0_ThrowsArgumentException()
    {
        var calculator = new Calculator();
        Assert.Throws<ArgumentException>(() => calculator.CurrentFailureIntensity(-1, 10, 5));
    }

    [Test]
    public void CurrentFailureIntensity_ZeroNu0_ThrowsArgumentException()
    {
        var calculator = new Calculator();
        Assert.Throws<ArgumentException>(() => calculator.CurrentFailureIntensity(1, 0, 5));
    }

    [Test]
    public void CurrentFailureIntensity_NegativeNu0_ThrowsArgumentException()
    {
        var calculator = new Calculator();
        Assert.Throws<ArgumentException>(() => calculator.CurrentFailureIntensity(1, -10, 5));
    }

    [Test]
    public void CurrentFailureIntensity_NegativeTau_ThrowsArgumentException()
    {
        var calculator = new Calculator();
        Assert.Throws<ArgumentException>(() => calculator.CurrentFailureIntensity(1, 10, -1));
    }

    [Test]
    public void ExpectedCumulativeFailures_AtStartOfExecution_IsZero()
    {
        var calculator = new Calculator();
        Assert.That(calculator.ExpectedCumulativeFailures(1, 10, 0), Is.EqualTo(0).Within(1e-9));
    }

    [Test]
    public void ExpectedCumulativeFailures_NormalExecutionTime_ReturnsExpectedValue()
    {
        var calculator = new Calculator();
        double expected = 10 * (1 - Math.Exp(-1));
        Assert.That(calculator.ExpectedCumulativeFailures(1, 10, 10), Is.EqualTo(expected).Within(1e-9));
    }

    [Test]
    public void ExpectedCumulativeFailures_ZeroLambda0_ThrowsArgumentException()
    {
        var calculator = new Calculator();
        Assert.Throws<ArgumentException>(() => calculator.ExpectedCumulativeFailures(0, 10, 5));
    }

    [Test]
    public void ExpectedCumulativeFailures_ZeroNu0_ThrowsArgumentException()
    {
        var calculator = new Calculator();
        Assert.Throws<ArgumentException>(() => calculator.ExpectedCumulativeFailures(1, 0, 5));
    }

    [Test]
    public void ExpectedCumulativeFailures_NegativeTau_ThrowsArgumentException()
    {
        var calculator = new Calculator();
        Assert.Throws<ArgumentException>(() => calculator.ExpectedCumulativeFailures(1, 10, -1));
    }

}
