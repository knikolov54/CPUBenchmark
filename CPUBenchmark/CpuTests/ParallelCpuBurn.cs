using CPUBenchmark.Application;
using CPUBenchmark.Models;

namespace CPUBenchmark.CpuTests;

public class ParallelCpuBurn(int seconds) : CpuTestBase("Parallel CPU Run")
{
    private int Seconds { get; init; } = seconds;

    /// Parallel CPU Burn (maxes out all cores)
    /// => Uses Parallel.For to spawn work on all logical cores
    /// => Tight loop ensures 100% CPU usage per core
    protected override void ExecuteTest()
    {
        var end = DateTime.UtcNow.AddSeconds(this.Seconds);

        Parallel.For(0, Environment.ProcessorCount, _ =>
        {
            while (DateTime.UtcNow < end)
            {
                // Tight spin loop
                double x = Math.Sqrt(12345.6789);
            }
        });
    }

    protected override TestType GetTestType() => TestType.ParallelCpuBurn;
}