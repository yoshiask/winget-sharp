using WinGet.Sharp.Enums;
using Xunit.Abstractions;

namespace WinGet.Sharp.Tests;

public class CommunityRepository
{
    private readonly ITestOutputHelper _log;

    public CommunityRepository(ITestOutputHelper log)
    {
        _log = log;
    }

    [Theory]
    [InlineData("YoYoGames.GameMaker.Studio.2", "2023.8.2.108")]
    [InlineData("7zip.7zip", "23.01")]
    [InlineData("MHNexus.HxD", "2.5")]
    public async Task GetManifest(string id, string version)
    {
        var manifest = await CommunityRepo.GetManifestAsync(id, version);

        Assert.NotNull(manifest);
        Assert.NotNull(manifest.ManifestVersion);
        Assert.Equal(ManifestType.Version, manifest.ManifestType);
        Assert.Equal(id, manifest.PackageIdentifier);
        Assert.Equal(version, manifest.PackageVersion);
        Assert.NotNull(manifest.DefaultLocale);
    }

    [Theory]
    [InlineData("YoYoGames.GameMaker.Studio.2", "2023.8.2.108")]
    [InlineData("7zip.7zip", "23.01")]
    [InlineData("MHNexus.HxD", "2.5")]
    public async Task GetInstaller(string id, string version)
    {
        var installer = await CommunityRepo.GetInstallerAsync(id, version);

        Assert.NotNull(installer);
        Assert.NotNull(installer.ManifestVersion);
        Assert.Equal(ManifestType.Installer, installer.ManifestType);
        Assert.Equal(id, installer.PackageIdentifier);
        Assert.Equal(version, installer.PackageVersion);

        Assert.NotNull(installer.Installers);
        Assert.NotEmpty(installer.Installers);

        foreach (var inst in installer.Installers)
        {
            _log.WriteLine($"{inst.InstallerType} {inst.Architecture} ({inst.InstallerUrl})");
        }
    }
}
