using Xunit;

namespace OsScout.Tests;

public sealed class OperatingSystemInfoTest
{
    [Theory]
    [InlineData("AlmaLinux.9.2", OperatingSystemType.Almalinux)]
    [InlineData("AlmaLinux.9.4", OperatingSystemType.Almalinux)]
    [InlineData("Alpine.3.8.5", OperatingSystemType.Alpine)]
    [InlineData("Alpine.3.9.6", OperatingSystemType.Alpine)]
    [InlineData("Alpine.3.10.9", OperatingSystemType.Alpine)]
    [InlineData("Alpine.3.11.13", OperatingSystemType.Alpine)]
    [InlineData("Alpine.3.12.12", OperatingSystemType.Alpine)]
    [InlineData("Alpine.3.13.12", OperatingSystemType.Alpine)]
    [InlineData("Alpine.3.14.9", OperatingSystemType.Alpine)]
    [InlineData("Alpine.3.15.7", OperatingSystemType.Alpine)]
    [InlineData("Alpine.3.16.4", OperatingSystemType.Alpine)]
    [InlineData("Alpine.3.17.2", OperatingSystemType.Alpine)]
    [InlineData("Alpine.3.18.0", OperatingSystemType.Alpine)]
    [InlineData("Alpine.3.19.0", OperatingSystemType.Alpine)]
    [InlineData("altlinux", OperatingSystemType.Altlinux)]
    [InlineData("altlinux.10", OperatingSystemType.Altlinux)]
    [InlineData("Amazon.2018.03", OperatingSystemType.Amazon)]
    [InlineData("Amazon.2022", OperatingSystemType.Amazon)]
    [InlineData("Amazon.2023", OperatingSystemType.Amazon)]
    [InlineData("arch", OperatingSystemType.Arch)]
    [InlineData("arch32", OperatingSystemType.Arch32)]
    [InlineData("archcraft", OperatingSystemType.Archcraft)]
    [InlineData("arcolinux", OperatingSystemType.ArcoLinux)]
    [InlineData("arkane", OperatingSystemType.Arkane)]
    [InlineData("artix", OperatingSystemType.Artix)]
    [InlineData("artix.xfce", OperatingSystemType.Artix)]
    [InlineData("Aurora.40", OperatingSystemType.Aurora)]
    [InlineData("Aurora.41", OperatingSystemType.Aurora)]
    [InlineData("Bazzite.40", OperatingSystemType.Bazzite)]
    [InlineData("blackarch", OperatingSystemType.BlackArch)]
    [InlineData("blendos", OperatingSystemType.BlendOs)]
    [InlineData("Bluefin.40", OperatingSystemType.Bluefin)]
    [InlineData("Bluefin.41", OperatingSystemType.Bluefin)]
    [InlineData("cachyos", OperatingSystemType.CachyOs)]
    [InlineData("Centos.8", OperatingSystemType.Centos)]
    [InlineData("Centos.9", OperatingSystemType.Centos)]
    [InlineData("chimera", OperatingSystemType.Chimera)]
    [InlineData("chimeraos", OperatingSystemType.ChimeraOs)]
    [InlineData("clear-linux-os", OperatingSystemType.ClearLinux)]
    [InlineData("debian", OperatingSystemType.Debian)]
    [InlineData("debian.7", OperatingSystemType.Debian)]
    [InlineData("debian.8", OperatingSystemType.Debian)]
    [InlineData("debian.9", OperatingSystemType.Debian)]
    [InlineData("debian.10", OperatingSystemType.Debian)]
    [InlineData("debian.11", OperatingSystemType.Debian)]
    [InlineData("debian.12", OperatingSystemType.Debian)]
    [InlineData("deepin.20.9", OperatingSystemType.Deepin)]
    [InlineData("devuan.5", OperatingSystemType.Devuan)]
    [InlineData("dragonfly.6.4", OperatingSystemType.Dragonfly)]
    [InlineData("elementary.6", OperatingSystemType.Elementary)]
    [InlineData("endeavouros", OperatingSystemType.EndeavourOs)]
    [InlineData("endless.5.1.1", OperatingSystemType.Endless)]
    [InlineData("eurolinux.9.2", OperatingSystemType.Eurolinux)]
    [InlineData("exherbo", OperatingSystemType.Exherbo)]
    [InlineData("fedora.cinnamon.36", OperatingSystemType.Fedora)]
    [InlineData("freebsd.13.0", OperatingSystemType.Freebsd)]
    [InlineData("freebsd.13.2", OperatingSystemType.Freebsd)]
    [InlineData("gentoo", OperatingSystemType.Gentoo)]
    [InlineData("kali.2018.4", OperatingSystemType.Kali)]
    [InlineData("nixos.23.05", OperatingSystemType.NixOs)]
    [InlineData("nixos.23.11", OperatingSystemType.NixOs)]
    [InlineData("nixos.24.05", OperatingSystemType.NixOs)]
    [InlineData("popos.20.04", OperatingSystemType.PopOs)]
    [InlineData("popos.22.04", OperatingSystemType.PopOs)]
    public void OperatingSystemInfo_WhenOSInfoIsProvided_ReturnsCorrectOSType(string fileName,
        OperatingSystemType expectedType)
    {
        // Arrange
        var file = Path.GetFullPath($"./Assets/{fileName}");
        var content = File.ReadAllText(file);

        // Act
        var osRelease = OperatingSystemInfo.GetOsInfo(content);

        // Assert
        Assert.Equal(expectedType, osRelease.Type);
    }
}