using CPUBenchmark.CpuTests;
using CPUBenchmark.Models;

namespace CPUBenchmark.Application;

public class TestRunner
{
    public TestResult RunTest(TestType testType)
    {
        Console.WriteLine("Running test type: " + testType);
        ICpuTest test = null;
        
        if (testType == TestType.CpuIntensiveMath)
        {
            test = new CpuIntensiveMath();
        }
       
        if (testType == TestType.PrimeCalculation)
        {
            Console.WriteLine("Enter max possible prime number: ");
            int maxNumber = int.Parse(Console.ReadLine());
            test = new PrimeCalculation(maxNumber);
        }
       
        if (testType == TestType.CpuIntensiveBranching)
        {
            Console.WriteLine("Enter number of iterations: ");
            int iterationsCount = int.Parse(Console.ReadLine());
            test = new CpuIntensiveBranching(iterationsCount);
        }
       
        if (testType == TestType.ParallelCpuBurn)
        {
            Console.WriteLine("Enter process duration in seconds: ");
            int processDuration = int.Parse(Console.ReadLine());
            
            test = new ParallelCpuBurn(processDuration);
        }
        
        if(test == null)
            return new TestResult();
        
        Console.WriteLine("Running test...");
        
        TestResult result = test.Run();
        
        return result;
    }
}