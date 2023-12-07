using Microsoft.Management.Deployment;
using Xunit.Abstractions;

namespace WinGet.Sharp.Tests;

public class Primary
{
    private readonly ITestOutputHelper _log;

    public Primary(ITestOutputHelper log)
    {
        _log = log;
    }

    [Fact]
    public async Task ListInstalledPackages()
    {
        PackageManager manager = WinGetFactory.CreatePackageManager();

        var catalogRef = manager.GetLocalPackageCatalog(LocalPackageCatalog.InstalledPackages);
        var catalog = catalogRef.Connect().PackageCatalog;

        FindPackagesOptions options = WinGetFactory.CreateFindPackagesOptions();
        var result = await catalog.FindPackagesAsync(options);
        Assert.Equal(FindPackagesResultStatus.Ok, result.Status);

        var matches = result.Matches.ToList();
        Assert.NotEmpty(matches);

        foreach (var match in matches)
        {
            var package = match.CatalogPackage;
            _log.WriteLine($"{package.Name} ({package.Id})");
        }
    }

    [Theory]
    [InlineData("blender")]
    [InlineData("Visual studio")]
    public async Task FilterInstalledPackages(string query)
    {
        PackageManager manager = WinGetFactory.CreatePackageManager();

        var catalogRef = manager.GetLocalPackageCatalog(LocalPackageCatalog.InstalledPackages);
        var catalog = catalogRef.Connect().PackageCatalog;

        var filter = WinGetFactory.CreatePackageMatchFilter();
        filter.Field = PackageMatchField.Name;
        filter.Option = PackageFieldMatchOption.ContainsCaseInsensitive;
        filter.Value = query;

        FindPackagesOptions options = WinGetFactory.CreateFindPackagesOptions();
        options.Filters.Add(filter);

        var result = await catalog.FindPackagesAsync(options);
        Assert.Equal(FindPackagesResultStatus.Ok, result.Status);

        var matches = result.Matches.ToList();
        Assert.NotEmpty(matches);

        foreach (var match in matches)
        {
            var package = match.CatalogPackage;
            _log.WriteLine($"{package.Name} ({package.Id})");
        }
    }

    [Theory]
    [InlineData("blender")]
    [InlineData("Visual studio")]
    [InlineData("trumpet")]
    public async Task FilterCommunityRepoPackages(string query)
    {
        PackageManager manager = WinGetFactory.CreatePackageManager();

        var catalogRef = manager.GetPredefinedPackageCatalog(PredefinedPackageCatalog.OpenWindowsCatalog);
        var catalog = catalogRef.Connect().PackageCatalog;

        var filter = WinGetFactory.CreatePackageMatchFilter();
        filter.Field = PackageMatchField.Name;
        filter.Option = PackageFieldMatchOption.ContainsCaseInsensitive;
        filter.Value = query;

        FindPackagesOptions options = WinGetFactory.CreateFindPackagesOptions();
        options.Filters.Add(filter);

        var result = await catalog.FindPackagesAsync(options);
        Assert.Equal(FindPackagesResultStatus.Ok, result.Status);

        var matches = result.Matches.ToList();
        Assert.NotEmpty(matches);

        foreach (var match in matches)
        {
            var package = match.CatalogPackage;
            _log.WriteLine($"{package.Name} ({package.Id})");
        }
    }
}