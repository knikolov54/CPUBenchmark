using CPUBenchmark.Application;
using CPUBenchmark.Controllers;
using CPUBenchmark.Models;
using CPUBenchmark.Views;

namespace CPUBenchmark;

class Program
{
    static void Main(string[] args)
    {
        IConsoleView view = new ConsoleView();

        view.ShowTitle();
        view.ShowCpuStatus();

        TestType userInput = view.ShowMenuAndGetChoice();
        
        var runner = new TestRunner(view);
        
       TestResult testResult = runner.RunTest(userInput);

        view.RenderResults(testResult);

        view.PromptContinue();
    }
}