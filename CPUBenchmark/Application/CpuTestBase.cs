using System.Diagnostics;
using CPUBenchmark.Models;

namespace CPUBenchmark.Application;

public abstract class CpuTestBase(string name) : ICpuTest
{
    public string Name { get; set; } = name;
    protected abstract void ExecuteTest();
    protected abstract TestType GetTestType();

    public TestResult Run()
    {
        var timer = new Stopwatch();

        timer.Start();

        ExecuteTest();

        timer.Stop();

        return new TestResult
        {
            TestType = GetTestType(),
            TimeElapsed = timer.ElapsedMilliseconds
        };
    }
}