using CPUBenchmark.Models;
using CPUBenchmark.Application;
using CPUBenchmark.Views;

namespace CPUBenchmark;

class Program
{
    static void Main(string[] args)
    {
        TesterView view = new TesterView();
        
        TestRunner testRunner = new TestRunner();

        TestType userInput = view.ShowAvailableTests();

        TestResult testResult = testRunner.RunTest(userInput);
        
        view.ShowTestResults(testResult);
    }
}