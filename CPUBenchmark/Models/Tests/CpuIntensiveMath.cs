using System.Diagnostics;

namespace CPUBenchmark.Models;

public class CpuIntensiveMath : ICpuTest
{
    public TestResult Run()
    {
        long iterations = 500_000_000;
        double result = 0;

        var timer = new Stopwatch();
        timer.Start();

        for (long i = 0; i < iterations; i++)
        {
            result += Math.Sqrt(i) * Math.Sin(i) / (Math.Cos(i) + 1.000001);
        }

        timer.Stop();

        return new TestResult
        {
            TestType = TestType.CpuIntensiveMath,
            Value = timer.ElapsedMilliseconds
        };
    }
}