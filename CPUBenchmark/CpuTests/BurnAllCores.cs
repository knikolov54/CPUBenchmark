using System.Diagnostics;

namespace CPUBenchmark.Models;

public class ParallelCpuBurn : ICpuTest
{
    public TestResult Run()
    {
        Console.Write("Enter burn duration (seconds): ");
        int seconds = int.Parse(Console.ReadLine());

        var timer = new Stopwatch();

        timer.Start();

        BurnAllCores(seconds);

        timer.Stop();

        return new TestResult
        {
            TestType = TestType.ParallelCpuBurn,
            Value = timer.ElapsedMilliseconds
        };
    }

    /// Parallel CPU Burn (maxes out all cores)
    /// => Uses Parallel.For to spawn work on all logical cores
    /// => Tight loop ensures 100% CPU usage per core
    private void BurnAllCores(int seconds)
    {
        var end = DateTime.UtcNow.AddSeconds(seconds);

        Parallel.For(0, Environment.ProcessorCount, _ =>
        {
            while (DateTime.UtcNow < end)
            {
                // Tight spin loop
                double x = Math.Sqrt(12345.6789);
            }
        });
    }
}