using System.Diagnostics;

namespace CPUBenchmark.Models;

public class CpuIntensiveMath : ICpuTest
{
    public CpuIntensiveMath()
    {
    }

    public TestResult Run()
    {
        var timer = new Stopwatch();
        timer.Start();

        ExecuteMathTest();

        timer.Stop();

        return new TestResult
        {
            TestType = TestType.CpuIntensiveMath,
            Value = timer.ElapsedMilliseconds
        };
    }

    /// Pure Math Loop (tight, predictable, very CPU‑heavy)
    /// This is the classic approach: a huge number of floating‑point operations in a tight loop.
    /// => Heavy use of Math functions (slow)
    /// => Tight loop with no I/O
    /// => Predictable branching → maximizes raw CPU usage
    private void ExecuteMathTest()
    {
        long iterations = 500_000_000;
        double result = 0;

        for (long i = 0; i < iterations; i++)
        {
            result += Math.Sqrt(i) * Math.Sin(i) / (Math.Cos(i) + 1.000001);
        }
    }
}
        