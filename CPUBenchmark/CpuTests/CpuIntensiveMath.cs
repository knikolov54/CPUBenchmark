using CPUBenchmark.Application;

namespace CPUBenchmark.CpuTests;

public class CpuIntensiveMath : CpuTestBase
{
    /// Pure Math Loop (tight, predictable, very CPU‑heavy)
    /// This is the classic approach: a huge number of floating‑point operations in a tight loop.
    /// => Heavy use of Math functions (slow)
    /// => Tight loop with no I/O
    /// => Predictable branching → maximizes raw CPU usage
    protected override void ExecuteTest()
    {
        long iterations = 500_000_000;
        double result = 0;

        for (long i = 0; i < iterations; i++)
        {
            result += Math.Sqrt(i) * Math.Sin(i) / (Math.Cos(i) + 1.000001);
        }
    }
}
        