namespace CPUBenchmark.Models;

public class AppSettings
{
    public int Iterations { get; set; } = 1000000;
    public int MaxPrime { get; set; } = 100000;
    public int ProcessDurationSeconds { get; set; } = 5;
}
