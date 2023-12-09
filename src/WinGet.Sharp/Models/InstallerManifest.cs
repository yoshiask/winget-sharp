﻿using System.ComponentModel.DataAnnotations;
using WinGet.Sharp.Enums;

namespace WinGet.Sharp.Models;

/// <summary>
/// A representation of a single-file manifest representing an app installers in the OWC. v1.1.0
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.6.9.0 (Newtonsoft.Json v13.0.0.0)")]
public class InstallerManifest : IManifest
{
    [Required(AllowEmptyStrings = true)]
    [StringLength(128)]
    [RegularExpression(@"^[^\.\s\\/:\*\?""<>\|\x01-\x1f]{1,32}(\.[^\.\s\\/:\*\?""<>\|\x01-\x1f]{1,32}){1,3}$")]
    public string PackageIdentifier { get; set; }

    [Required(AllowEmptyStrings = true)]
    [StringLength(128)]
    [RegularExpression(@"^[^\\/:\*\?""<>\|\x01-\x1f]+$")]
    public string PackageVersion { get; set; }

    [StringLength(16, MinimumLength = 1)]
    public string Channel { get; set; }

    [StringLength(20)]
    [RegularExpression(@"^([a-zA-Z]{2,3}|[iI]-[a-zA-Z]+|[xX]-[a-zA-Z]{1,8})(-[a-zA-Z]{1,8})*$")]
    public string InstallerLocale { get; set; }

    /// <summary>
    /// The installer supported operating system
    /// </summary>
    [MaxLength(2)]
    public List<Platform> Platform { get; set; }

    [RegularExpression(@"^(0|[1-9][0-9]{0,3}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-5])(\.(0|[1-9][0-9]{0,3}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-5])){0,3}$")]
    public string MinimumOSVersion { get; set; }

    public InstallerType? InstallerType { get; set; }

    public Scope? Scope { get; set; }

    [MaxLength(3)]
    public List<InstallModes> InstallModes { get; set; }

    public InstallerSwitches InstallerSwitches { get; set; }

    /// <summary>
    /// List of additional non-zero installer success exit codes other than known default values by winget
    /// </summary>
    [MaxLength(16)]
    public List<long> InstallerSuccessCodes { get; set; }

    /// <summary>
    /// Installer exit codes for common errors
    /// </summary>
    [MaxLength(128)]
    public List<ExpectedReturnCode> ExpectedReturnCodes { get; set; }

    public UpgradeBehavior? UpgradeBehavior { get; set; }

    /// <summary>
    /// List of commands or aliases to run the package
    /// </summary>
    [MaxLength(16)]
    public List<string> Commands { get; set; }

    /// <summary>
    /// List of protocols the package provides a handler for
    /// </summary>
    [MaxLength(16)]
    public List<string> Protocols { get; set; }

    /// <summary>
    /// List of file extensions the package could support
    /// </summary>
    [MaxLength(256)]
    public List<string> FileExtensions { get; set; }

    public Dependencies Dependencies { get; set; }

    [StringLength(255)]
    [RegularExpression(@"^[A-Za-z0-9][-\.A-Za-z0-9]+_[A-Za-z0-9]{13}$")]
    public string PackageFamilyName { get; set; }

    [StringLength(255, MinimumLength = 1)]
    public string ProductCode { get; set; }

    /// <summary>
    /// List of APPX or MSIX installer capabilities
    /// </summary>
    [MaxLength(1000)]
    public List<string> Capabilities { get; set; }

    /// <summary>
    /// List of APPX or MSIX installer restricted capabilities
    /// </summary>
    [MaxLength(1000)]
    public List<string> RestrictedCapabilities { get; set; }

    /// <summary>
    /// Optional markets the package is allowed to be installed
    /// </summary>
    public List<string> Markets { get; set; }

    /// <summary>
    /// Optional markets the package is not allowed to be installed
    /// </summary>
    public List<string> ExcludedMarkets { get; set; }

    public bool? InstallerAbortsTerminal { get; set; }

    //[Newtonsoft.Json.JsonConverter(typeof(DateFormatConverter))]
    public DateTimeOffset? ReleaseDate { get; set; }

    public bool? InstallLocationRequired { get; set; }

    public bool? RequireExplicitUpgrade { get; set; }

    /// <summary>
    /// List of OS architectures the installer does not support
    /// </summary>
    public List<InstallerArchitecture> UnsupportedOSArchitectures { get; set; }

    /// <summary>
    /// List of ARP entries.
    /// </summary>
    [MaxLength(128)]
    public List<AppsAndFeaturesEntry> AppsAndFeaturesEntries { get; set; }

    public ElevationRequirement? ElevationRequirement { get; set; }

    [Required]
    [MinLength(1)]
    [MaxLength(1024)]
    public List<Installer> Installers { get; set; } = new List<Installer>();

    /// <summary>
    /// The manifest type
    /// </summary>
    [Required(AllowEmptyStrings = true)]
    public ManifestType ManifestType { get; set; } = ManifestType.Installer;

    /// <summary>
    /// The manifest syntax version
    /// </summary>
    [Required(AllowEmptyStrings = true)]
    [RegularExpression(@"^(0|[1-9][0-9]{0,3}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-5])(\.(0|[1-9][0-9]{0,3}|[1-5][0-9]{4}|6[0-4][0-9]{3}|65[0-4][0-9]{2}|655[0-2][0-9]|6553[0-5])){2}$")]
    public string ManifestVersion { get; set; } = "1.1.0";
}

