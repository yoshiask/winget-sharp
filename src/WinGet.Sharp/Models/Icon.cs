using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using WinGet.Sharp.Enums;

namespace WinGet.Sharp.Models;

[System.CodeDom.Compiler.GeneratedCode("NJsonSchema", "10.4.3.0 (Newtonsoft.Json v11.0.0.0)")]
public partial class Icon
{
    /// <summary>The url of the hosted icon file</summary>
    [StringLength(2048)]
    public string IconUrl { get; set; }

    /// <summary>The icon file type</summary>
    [Required(AllowEmptyStrings = true)]
    public IconFileType IconFileType { get; set; }

    /// <summary>Optional icon resolution</summary>
    public IconResolution? IconResolution { get; set; }

    /// <summary>Optional icon theme</summary>
    public IconTheme? IconTheme { get; set; }

    /// <summary>Optional Sha256 of the icon file</summary>
    [RegularExpression(@"^[A-Fa-f0-9]{64}$")]
    public string IconSha256 { get; set; }

    private IDictionary<string, object> _additionalProperties = new Dictionary<string, object>();

    [JsonExtensionData]
    public IDictionary<string, object> AdditionalProperties
    {
        get => _additionalProperties;
        set => _additionalProperties = value;
    }
}
