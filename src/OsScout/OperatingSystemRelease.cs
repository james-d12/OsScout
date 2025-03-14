namespace OsScout;

public record struct OperatingSystemRelease
{
    public OperatingSystemType Type { get; set; }
    public string Id { get; set; }
    public string Name { get; set; }
    public string Version { get; set; }
    public string PrettyName { get; set; }
    public string VersionId { get; set; }
    public string HomeUrl { get; set; }
    public string BugReportUrl { get; set; }
}