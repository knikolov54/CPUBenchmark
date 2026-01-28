using CPUBenchmark.Models;

namespace CPUBenchmark.Application;

public class CpuTester
{
    public TestResult RunTest(TestType testType)
    {
        Console.WriteLine("Running test type: " + testType);
       
        TestResult result = new TestResult();
        
        result.TestType = testType;
        result.Value = 2343;
        
        return result;
    }
}