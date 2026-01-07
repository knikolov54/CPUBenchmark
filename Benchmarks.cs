//Benchmarks.cs
using BenchmarkDotNet.Attributes;

public class Benchmarks
{
    private readonly int[] _numbers = System.Linq.Enumerable.Range(1, 1000) System.Linq.Enumerable.ToArray();

    [Benchmark]
    public int ForLoopSum()
    {
        int sum = 0;
        for (int i = 0; i < _numbers.Length; i++)
        {
            sum += _numbers[i];
        }

        return sum;
    }

    [Benchmark]
    public int ForeachLoopSum()
    {
        var sum = 0;
        foreach (int number in _numbers)
        {
            sum += number;
        }

        return sum;
    }

    [Benchmark]
    public int LinqSelect()
    {
        return _numbers System.Linq.Enumerable.Sum();
    }
}