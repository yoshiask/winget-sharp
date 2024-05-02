#if WINDOWS

using Microsoft.Management.Deployment;
using System.Diagnostics.Contracts;
using System.Runtime.InteropServices;
using WinRT;

namespace WinGet.Sharp;

public static class WinGetFactory
{
    [Pure]
    public static PackageManager CreatePackageManager() => CreateInstance<PackageManager>(new("C53A4F16-787E-42A4-B304-29EFFB4BF597"));

    [Pure]
    public static FindPackagesOptions CreateFindPackagesOptions() => CreateInstance<FindPackagesOptions>(new("572DED96-9C60-4526-8F92-EE7D91D38C1A"));

    [Pure]
    public static CreateCompositePackageCatalogOptions CreateCompositePackageCatalogOptions() => CreateInstance<CreateCompositePackageCatalogOptions>(new("526534B8-7E46-47C8-8416-B1685C327D37"));

    [Pure]
    public static InstallOptions CreateInstallOptions() => CreateInstance<InstallOptions>(new("1095F097-EB96-453B-B4E6-1613637F3B14"));

    [Pure]
    public static UninstallOptions CreateUninstallOptions() => CreateInstance<UninstallOptions>(new("E1D9A11E-9F85-4D87-9C17-2B93143ADB8D"));

    [Pure]
    public static PackageMatchFilter CreatePackageMatchFilter() => CreateInstance<PackageMatchFilter>(new("D02C9DAF-99DC-429C-B503-4E504E4AB000"));

    [Pure]
    public static DownloadOptions CreateDownloadOptions() => CreateInstance<DownloadOptions>(new("4CBABE76-7322-4BE4-9CEA-2589A80682DC"));

    [Pure]
    public static AuthenticationArguments CreateAuthenticationArguments() => CreateInstance<AuthenticationArguments>(new("BA580786-BDE3-4F6C-B8F3-44698AC8711A"));

#if false
    public static ConfigurationStaticFunctions CreateConfigurationStaticFunctions() => CreateInstance<ConfigurationStaticFunctions>(new("73D763B7-2937-432F-A97A-D98A4A596126"));
    public static PackageManagerSettings CreatePackageManagerSettings() => CreateInstance<PackageManagerSettings>(new("80CF9D63-5505-4342-B9B4-BB87895CA8BB"));
#endif

    [Pure]
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

#endif
