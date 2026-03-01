using System.Diagnostics;

namespace CPUBenchmark.Models;

public class CpuIntensiveBranching : ICpuTest
{
    public TestResult Run()
    {
        Console.Write("Enter iteration count: ");
        long iterations = long.Parse(Console.ReadLine());

        var timer = new Stopwatch();

        timer.Start();

        long result = Execute(iterations);

        timer.Stop();

        return new TestResult
        {
            TestType = TestType.CpuIntensiveBranching,
            Value = timer.ElapsedMilliseconds
        };
    }

    private long Execute(long iterations)
    {
        long sum = 0;

        for (long i = 0; i < iterations; i++)
        {
            if ((i * 13) % 7 == 0)
                sum += i;
            else if ((i * 17) % 11 == 0)
                sum -= i;
            else
                sum ^= i;
        }

        return sum;
    }
}