using CPUBenchmark.Models;

namespace CPUBenchmark.Application;

public interface IConsoleView
{
    void ShowTitle();
    
    TestType ShowMenuAndGetChoice();
    
    AppSettings ConfigureSettings(AppSettings current);

    void ShowCpuStatus();
    
    void PromptContinue();

    void RenderResults(TestResult results);
}