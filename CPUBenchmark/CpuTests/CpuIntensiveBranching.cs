using CPUBenchmark.Application;
using CPUBenchmark.Models;

namespace CPUBenchmark.CpuTests;

public class CpuIntensiveBranching(int iterations) : CpuTestBase("Branch-Heavy CPU Load")
{
    public int IterationsCount { get; init; } = iterations;

    /// Branch‑Heavy CPU Load (stresses branch prediction)
    /// => Lots of unpredictable branches
    /// => Integer arithmetic + bitwise ops
    /// => Good for testing CPU branch prediction behavior
    protected override void ExecuteTest()
    {
        long sum = 0;

        for (long i = 0; i < this.IterationsCount; i++)
        {
            if ((i * 13) % 7 == 0)
                sum += i;
            else if ((i * 17) % 11 == 0)
                sum -= i;
            else
                sum ^= i;
        }
    }

    protected override TestType GetTestType() => TestType.CpuIntensiveBranching;
}