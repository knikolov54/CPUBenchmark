using CPUBenchmark.Application;
using CPUBenchmark.CpuTests;
using CPUBenchmark.Models;
using Spectre.Console;

namespace CPUBenchmark.Controllers;

public class TestRunner( IConsoleView view)
{
    public TestResult RunTest(TestType testType)
    {
        var test = GetTest(testType, view.ConfigureSettings(new AppSettings()));
        
        var result = new TestResult();
        var cpuUsage = 0f;
        var isRunning = true;
        var table = new Table().Border(TableBorder.Rounded).Expand();

        table.AddColumn("Status");
        table.AddColumn("CPU Load");

        AnsiConsole.Live(table)
            .Start(ctx =>
            {
                var monitorTask = Task.Run(() =>
                {
                    while (isRunning)
                        cpuUsage = CpuInfo.Utilization();
                });

                table.AddRow(new Markup($"[yellow]Running {test.Name}...[/]"), new Markup($"[red]{cpuUsage}%[/]"));
                ctx.Refresh();

                var testTask = Task.Run(() =>
                {
                    result = test.Run();
                    isRunning = false;
                });

                while (isRunning)
                {
                    table.Rows.Update(0, 0, new Markup($"[yellow]Running {test.Name}...[/]"));
                    table.Rows.Update(0, 1, new Markup($"[red]{cpuUsage}%[/]"));
                    ctx.Refresh();
                    Thread.Sleep(100);
                }

                table.Rows.Update(0, 0, new Markup($"[green]Completed {test.Name}[/]"));
                table.Rows.Update(0, 1, new Markup($"[blue]{cpuUsage}%[/]"));
                ctx.Refresh();
                
                testTask.Wait();
                monitorTask.Wait();
            });
    
        return result;
    }
    
    private ICpuTest GetTest(TestType testType, AppSettings settings)
    {
        return testType switch
        {
            TestType.CpuIntensiveMath => new CpuIntensiveMath(),
            TestType.PrimeCalculation => new PrimeCalculation(settings.MaxPrime),
            TestType.CpuIntensiveBranching => new CpuIntensiveBranching(settings.Iterations),
            TestType.ParallelCpuBurn => new ParallelCpuBurn(settings.ProcessDurationSeconds),
            _ => new CpuIntensiveMath()
        };
    }
}