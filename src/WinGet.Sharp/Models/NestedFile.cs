using System.ComponentModel.DataAnnotations;
using WinGet.Sharp.Enums;

namespace WinGet.Sharp.Models;

public class NestedFile
{
    /// <summary>
    /// The relative path to the installer file contained within the archive.
    /// </summary>
    [Required]
    public string RelativeFilePath { get; set; }

    /// <summary>
    /// The alias which is added to the PATH for calling the package from the command line.
    /// Only valid when <see cref="Installer.NestedInstallerType"/> is <see cref="InstallerType.Portable"/>.
    /// </summary>
    public string? PortableCommandAlias { get; set; }
}