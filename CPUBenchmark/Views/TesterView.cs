using CPUBenchmark.Models;

namespace CPUBenchmark.Views;

public class TesterView
{
    public TestType ShowAvailableTests()
    {
        Console.WriteLine("Choose a test:");
        Console.WriteLine("1. Fibbonaci");
        Console.WriteLine("2. Matrix Multiplication");
        Console.WriteLine("3. Trigonometry");
        Console.WriteLine("4. Floating point operations");
        
        int input = int.Parse(Console.ReadLine());
        
        return (TestType)input;
    }

    public void ShowTestResults(TestResult result)
    {
        Console.WriteLine("Test result: " + result.Value);
    }
}