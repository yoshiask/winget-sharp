using System.ComponentModel.DataAnnotations;

namespace WinGet.Sharp.Models;

/// <summary>
/// A representation of a multiple-file manifest representing a default app metadata in the OWC. v1.1.0
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.6.9.0 (Newtonsoft.Json v13.0.0.0)")]
public class DefaultLocale : Locale
{
    public DefaultLocale()
    {
        ManifestType = Enums.ManifestType.DefaultLocale;
    }

    /// <summary>
    /// The most common package term
    /// </summary>
    [StringLength(40, MinimumLength = 1)]
    public string Moniker { get; set; }
}
