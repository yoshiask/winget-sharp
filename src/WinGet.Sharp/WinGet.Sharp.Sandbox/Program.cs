using Microsoft.Management.Deployment;
using System;
using System.Threading.Tasks;

namespace WinGet.Sharp.Sandbox;

internal class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Guid clsid = new("C53A4F16-787E-42A4-B304-29EFFB4BF597");
        Type packageManagerType = Type.GetTypeFromCLSID(clsid, true)!;
        var manager = (PackageManager)Activator.CreateInstance(packageManagerType)!;

        var catalogRef = manager.GetLocalPackageCatalog(LocalPackageCatalog.InstalledPackages);
        var catalog = catalogRef.Connect().PackageCatalog;

        clsid = new("572DED96-9C60-4526-8F92-EE7D91D38C1A");
        var findPackagesOptionsType = Type.GetTypeFromCLSID(clsid, true)!;
        var options = (FindPackagesOptions)Activator.CreateInstance(findPackagesOptionsType)!;

        var results = await catalog.FindPackagesAsync(options);

        foreach (var match in results.Matches)
        {
            var package = match.CatalogPackage;

        }
    }
}