using CPUBenchmark.Application;
using Spectre.Console;
using CPUBenchmark.Models;
using CPUBenchmark.Controllers;

namespace CPUBenchmark.Views;

public class ConsoleView : IConsoleView
{
    public void ShowTitle()
    {
        AnsiConsole.Write(new FigletText("CPU Benchmark").Centered().Color(Color.Red));
    }

    public TestType ShowMenuAndGetChoice()
    {
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose a [blue]test type[/]:")
                .PageSize(10)
                .AddChoices(Enum.GetNames<TestType>()));

        return Enum.Parse<TestType>(choice);
        
    }

    public AppSettings ConfigureSettings(AppSettings current)
    {
        var settings = new AppSettings
        {
            Iterations = AnsiConsole.Ask<int>($"Enter number of [green]iterations[/] (current: {current.Iterations}): ", current.Iterations),
            MaxPrime = AnsiConsole.Ask<int>($"Enter max [green]prime number[/] (current: {current.MaxPrime}): ", current.MaxPrime),
            ProcessDurationSeconds = AnsiConsole.Ask<int>($"Enter process [green]duration[/] in seconds (current: {current.ProcessDurationSeconds}): ", current.ProcessDurationSeconds)
        };
        return settings;
    }

    public void ShowCpuStatus()
    {
        AnsiConsole.Status()
            .Start("Checking CPU status...", ctx => 
            {
                var table = new Table().Border(TableBorder.Rounded);
                table.AddColumn("Property");
                table.AddColumn("Value");

                table.AddRow("CPU Name", CpuInfo.CpuName());
                table.AddRow("Physical Cores", CpuInfo.PhysicalCoreCount().ToString());
                table.AddRow("Current Usage", $"{CpuInfo.Utilization()}%");

                AnsiConsole.Write(table);

                ShowCacheInfo();
            });
    }

    public void ShowHeader(string title)
    {
        AnsiConsole.Write(new Rule($"[yellow]{title}[/]").LeftJustified());
    }

    public void ShowError(string message)
    {
        AnsiConsole.Write(new Panel($"[red]Error: {message}[/]").BorderColor(Color.Red));
    }

    public void ShowOutOfMemory()
    {
        AnsiConsole.Write(new Panel("[bold red]OUT OF MEMORY ERROR[/]").BorderColor(Color.Red));
    }

    public void PromptContinue()
    {
        AnsiConsole.MarkupLine("[grey]Press Enter to continue...[/]");
        Console.ReadLine();
    }

    public void RenderResults(TestResult results)
    {
        var panel = new Panel(new Markup($"[green]Test Type:[/] {results.TestType}\n[green]Time Elapsed:[/] {results.TimeElapsed} ms"))
        {
            Header = new PanelHeader("Test Results"),
            Border = BoxBorder.Rounded,
            Padding = new Padding(1, 1, 1, 1)
        };
        AnsiConsole.Write(panel);
    }
    
    private void ShowCacheInfo()
    {
        var table = new Table().Border(TableBorder.Rounded).Title("Cache Information");

        table.AddColumn("Level");
        table.AddColumn("Size");

        foreach (var ci in CpuInfo.CacheInfo())
            table.AddRow(ci.Level, $"{ci.Size} KB");

        AnsiConsole.Write(table);
    }
}
