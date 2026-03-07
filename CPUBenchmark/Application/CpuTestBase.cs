using System.Diagnostics;
using CPUBenchmark.Models;

namespace CPUBenchmark.Application;

public abstract class CpuTestBase : ICpuTest
{
    protected abstract void ExecuteTest();
    
    public TestResult Run()
    {
        var timer = new Stopwatch();

        timer.Start();
        
        ExecuteTest();

        timer.Stop();

        return new TestResult
        {
            TestType = TestType.PrimeCalculation,
            TimeElapsed = timer.ElapsedMilliseconds
        };
    }
}