using CPUBenchmark.Models;

namespace CPUBenchmark.Application;

public class CpuTester
{
    public TestResult RunTest(TestType testType)
    {
        Console.WriteLine("Running test type: " + testType);
        TestResult result = new TestResult();
        
        if (testType == TestType.MatrixMultiplication)
        {
            ICpuTest test = new MatrixMultiplication();

            result = test.Run();
        }
       
        
 
        return result;
    }
}