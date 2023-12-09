using WinGet.Sharp.Enums;

namespace WinGet.Sharp.Models;

public interface IManifest
{
    public ManifestType ManifestType { get; set; }

    public string ManifestVersion { get; set; }
}
