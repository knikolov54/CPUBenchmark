using CPUBenchmark.Application;
using CPUBenchmark.Models;

namespace CPUBenchmark.CpuTests;

public class PrimeCalculation(int maxNumber) : CpuTestBase("Prime Number Calculation")
{
    public int MaxNumber { get; init; } = maxNumber;

    /// Prime Number Calculation (real‑world CPU load)
    /// => Nested loops
    /// => Non‑trivial math
    /// => Good for simulating real computational workloads
    protected override void ExecuteTest()
    {
        var primes = new List<int>();

        for (int i = 2; i <= this.MaxNumber; i++)
        {
            bool isPrime = true;

            for (int j = 2; j * j <= i; j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime)
                primes.Add(i);
        }
    }

    protected override TestType GetTestType() => TestType.PrimeCalculation;
}