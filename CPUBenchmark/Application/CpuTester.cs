using CPUBenchmark.Models;

namespace CPUBenchmark.Application;

public class CpuTester
{
    public TestResult RunTest(TestType testType)
    {
        Console.WriteLine("Running test type: " + testType);
        TestResult result = new TestResult();
        
        if (testType == TestType.PrimeCalculation)
        {
            ICpuTest test = new PrimeCalculation();

            result = test.Run();
        }
       
        
 
        return result;
    }
}