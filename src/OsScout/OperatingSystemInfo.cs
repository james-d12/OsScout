using System.Runtime.InteropServices;

namespace OsScout;

public static class OperatingSystemInfo
{
    private const string ReleaseInfoFile = "/etc/os-release";
    private static bool IsWindows() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
    private static bool IsMacOs() => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);
    private static bool IsLinux() => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

    public static OperatingSystemType GetOperatingSystem()
    {
        if (IsLinux()) return GetOperatingSystemLinux();
        if (IsMacOs()) return GetOperatingSystemMacOs();
        if (IsWindows()) return GetOperatingSystemWindows();

        return OperatingSystemType.Other;
    }

    public static OperatingSystemType GetOperatingSystemLinux()
    {
        if (!File.Exists(ReleaseInfoFile))
        {
            return OperatingSystemType.Other;
        }

        var content = File.ReadAllText(ReleaseInfoFile);
        var osRelease = GetOsReleaseInfo(content);
        return osRelease.Type;
    }

    private static OperatingSystemType GetOperatingSystemMacOs()
    {
        return OperatingSystemType.MacOs;
    }

    private static OperatingSystemType GetOperatingSystemWindows()
    {
        return OperatingSystemType.Windows;
    }

    public static OperatingSystemRelease GetOsReleaseInfo(string content)
    {
        var osRelease = new OperatingSystemRelease();

        foreach (var line in content.Split("\n"))
        {
            var parts = line.Split('=');
            var key = parts.ElementAtOrDefault(0)?.Trim().Replace("\"", "").Replace("'", "").ToLowerInvariant();
            var value = parts.ElementAtOrDefault(1)?.Trim().Replace("\"", "").Replace("'", "").ToLowerInvariant();

            if (key is null || value is null) continue;

            switch (key)
            {
                case "id": osRelease.Id = value; break;
                case "name": osRelease.Name = value; break;
                case "version": osRelease.Version = value; break;
                case "pretty_name": osRelease.PrettyName = value; break;
                case "version_id": osRelease.VersionId = value; break;
                case "home_url": osRelease.HomeUrl = value; break;
                case "bug_report_url": osRelease.BugReportUrl = value; break;
            }
        }

        if (!string.IsNullOrEmpty(osRelease.Id))
        {
            osRelease.Type = OperatingSystemLinuxDistribution.Distributions[osRelease.Id];
        }

        return osRelease;
    }
}