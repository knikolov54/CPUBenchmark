using System.Diagnostics;

namespace CPUBenchmark.Models;

public class PrimeCalculation : ICpuTest
{
    public TestResult Run()
    {
        Console.Write("Enter max number: ");
        int max = int.Parse(Console.ReadLine());

        var timer = new Stopwatch();

        timer.Start();

        CalculatePrimes(max);

        timer.Stop();

        return new TestResult
        {
            TestType = TestType.PrimeCalculation,
            Value = timer.ElapsedMilliseconds
        };
    }

    /// Prime Number Calculation (real‑world CPU load)
    /// => Nested loops
    /// => Non‑trivial math
    /// => Good for simulating real computational workloads
    private void CalculatePrimes(int max)
    {
        var primes = new List<int>();

        for (int i = 2; i <= max; i++)
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
}