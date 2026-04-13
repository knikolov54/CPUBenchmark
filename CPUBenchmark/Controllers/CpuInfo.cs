using System.Diagnostics;
using System.Management;
using CPUBenchmark.Models;

namespace CPUBenchmark.Controllers;

public static class CpuInfo
{
    public static string CpuName()
    {
        using var searcher = new ManagementObjectSearcher("select Name from Win32_Processor");
        foreach (var item in searcher.Get())
            return item["Name"].ToString();

        return "Unknown CPU";
    }

    public static float Utilization()
    {
        var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
        cpuCounter.NextValue();
        Thread.Sleep(500);
        return (float)Math.Round(cpuCounter.NextValue(), 2);
    }

    public static int PhysicalCoreCount()
    {
        using var searcher = new ManagementObjectSearcher("select NumberOfCores from Win32_Processor");
        foreach (var item in searcher.Get())
            return Convert.ToInt32(item["NumberOfCores"]);

        return 0;
    }

    public static IEnumerable<CacheInfo> CacheInfo()
    {
        using var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_CacheMemory");
        
        foreach (ManagementObject obj in searcher.Get())
        {
            string level = obj["Level"]?.ToString() ?? "Unknown";
            string size = obj["InstalledSize"]?.ToString() ?? "0";

            string levelName = level switch
            {
                "3" => "L1",
                "4" => "L2",
                "5" => "L3",
                _ => $"Level {level}"
            };

            yield return new CacheInfo
            {
                Level = levelName,
                Size = Convert.ToInt32(size)
            };
        }
    }
}

