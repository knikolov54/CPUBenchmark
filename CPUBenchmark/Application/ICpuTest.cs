using CPUBenchmark.Models;

namespace CPUBenchmark.Application;

public interface ICpuTest
{
    string Name { get; set; }
    TestResult Run();
}