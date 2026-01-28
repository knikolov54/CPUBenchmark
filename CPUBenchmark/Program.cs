using CPUBenchmark.Models;
using CPUBenchmark.Application;
using CPUBenchmark.Views;

namespace CPUBenchmark;

class Program
{
    static void Main(string[] args)
    {
        var view = new TesterView();
        var tester = new CpuTester();

        TestType userInput = view.ShowAvailableTests();

        TestResult testResult = tester.RunTest(userInput);
        
        view.ShowTestResults(testResult);
    }
}