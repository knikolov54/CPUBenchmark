/// Pure Math Loop (tight, predictable, very CPU‑heavy)
/// This is the classic approach: a huge number of floating‑point operations in a tight loop.
/// => Heavy use of Math functions (slow)
/// => Tight loop with no I/O
/// => Predictable branching → maximizes raw CPU usage
public static double CpuIntensiveMath(long iterations = 500_000_000)
{
    double result = 0;

    for (long i = 0; i < iterations; i++)
    {
        result += Math.Sqrt(i) * Math.Sin(i) / (Math.Cos(i) + 1.000001);
    }

    return result;
}


/// Branch‑Heavy CPU Load (stresses branch prediction)
/// => Lots of unpredictable branches
/// => Integer arithmetic + bitwise ops
/// => Good for testing CPU branch prediction behavior
public static long CpuIntensiveBranching(long iterations = 300_000_000)
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

/// Parallel CPU Burn (maxes out all cores)
/// => Uses Parallel.For to spawn work on all logical cores
/// => Tight loop ensures 100% CPU usage per core
public static void BurnAllCores(int seconds = 10)
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

/// Prime Number Calculation (real‑world CPU load)
/// => Nested loops
/// => Non‑trivial math
/// => Good for simulating real computational workloads
public static List<int> CalculatePrimes(int max)
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

    return primes;
}
