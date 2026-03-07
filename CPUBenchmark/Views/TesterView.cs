using CPUBenchmark.Models;

namespace CPUBenchmark.Views;

public class TesterView
{
    public TestType ShowAvailableTests()
    {
        Console.WriteLine("Choose a test:");
        Console.WriteLine("1. CpuIntensiveMath");
        Console.WriteLine("2. PrimeCalculation");
        Console.WriteLine("3. CpuIntensiveMath");
        Console.WriteLine("4. ParallelCpuBurn");
        
        int input = int.Parse(Console.ReadLine());
        
        return (TestType)input;
    }

    public void ShowTestResults(TestResult result)
    {
        Console.WriteLine("Test result: " + result.Value);
    }
}