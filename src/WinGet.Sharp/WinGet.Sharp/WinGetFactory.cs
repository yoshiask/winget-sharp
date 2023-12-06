using Microsoft.Management.Deployment;
using System.Runtime.InteropServices;
using WinRT;

namespace WinGet.Sharp;

public static class WinGetFactory
{
    public static PackageManager CreatePackageManager() => CreateInstance<PackageManager>(new("C53A4F16-787E-42A4-B304-29EFFB4BF597"));
    public static FindPackagesOptions CreateFindPackagesOptions() => CreateInstance<FindPackagesOptions>(new("572DED96-9C60-4526-8F92-EE7D91D38C1A"));
    public static CreateCompositePackageCatalogOptions CreateCompositePackageCatalogOptions() => CreateInstance<CreateCompositePackageCatalogOptions>(new("526534B8-7E46-47C8-8416-B1685C327D37"));
    public static InstallOptions CreateInstallOptions() => CreateInstance<InstallOptions>(new("1095F097-EB96-453B-B4E6-1613637F3B14"));
    public static UninstallOptions CreateUninstallOptions() => CreateInstance<UninstallOptions>(new("E1D9A11E-9F85-4D87-9C17-2B93143ADB8D"));
    public static PackageMatchFilter CreatePackageMatchFilter() => CreateInstance<PackageMatchFilter>(new("D02C9DAF-99DC-429C-B503-4E504E4AB000"));

#if false
    public static ConfigurationStaticFunctions CreateConfigurationStaticFunctions() => CreateInstance<ConfigurationStaticFunctions>(new("73D763B7-2937-432F-A97A-D98A4A596126"));
    public static DownloadOptions CreateDownloadOptions() => CreateInstance<DownloadOptions>(new("4CBABE76-7322-4BE4-9CEA-2589A80682DC"));
#endif

    private static T CreateInstance<T>(Guid clsid)
    {
        T obj;
        Type packageManagerType = Type.GetTypeFromCLSID(clsid, true)!;
        var unk = Activator.CreateInstance(packageManagerType)!;
        
        unsafe
        {
            var pUnk = Marshal.GetIUnknownForObject(unk);
            obj = MarshalInspectable<T>.FromAbi(pUnk);
        }

        return obj;
    }
}
