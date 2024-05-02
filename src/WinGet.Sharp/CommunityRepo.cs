using Flurl;
using Flurl.Http;
using System.Globalization;
using WinGet.Sharp.Models;
using WinGet.Sharp.Enums;
using YamlDotNet.Serialization;

namespace WinGet.Sharp;

public static class CommunityRepo
{
    private static readonly IDeserializer _deserializer = new DeserializerBuilder()
        .WithTypeConverter(new YamlStringEnumConverter())
        .IgnoreUnmatchedProperties()
        .Build();

    public static Task<VersionManifest> GetManifestAsync(string id, string version, CancellationToken cancellationToken = default)
    {
        return GetAndDeserializeAsync<VersionManifest>(id, version, cancellationToken: cancellationToken);
    }

    public static Task<InstallerManifest> GetInstallerAsync(string id, string version, CancellationToken cancellationToken = default)
    {
        return GetAndDeserializeAsync<InstallerManifest>(id, version, "installer", cancellationToken);
    }

    public static Task<Locale> GetLocaleAsync(string id, string version, string locale, CancellationToken cancellationToken = default)
    {
        return GetAndDeserializeAsync<Locale>(id, version, $"locale.{locale}", cancellationToken);
    }

    public static Task<Locale> GetLocaleAsync(string id, string version, CultureInfo culture, CancellationToken cancellationToken = default)
    {
        return GetLocaleAsync(id, version, culture.ToString(), cancellationToken);
    }

    public static async Task<DefaultLocale> GetDefaultLocaleAsync(string id, string version, CancellationToken cancellationToken = default)
    {
        var manifest = await GetManifestAsync(id, version, cancellationToken);
        return await GetAndDeserializeAsync<DefaultLocale>(id, version,
            $"locale.{manifest.DefaultLocale}", cancellationToken);
    }

    public static Url BuildManifestUrl(string id, string version, ManifestType manifestType)
    {
        if (manifestType == ManifestType.Manifest)
            return BuildManifestUrl(id, version);

        var manifestString = manifestType.ToString();
        manifestString = char.ToLower(manifestString[0]) + manifestString.Substring(1);

        return BuildManifestUrl(id, version, manifestString);
    }

    private static async Task<TManifest> GetAndDeserializeAsync<TManifest>(string id, string version, string? manifestType = null, CancellationToken cancellationToken = default)
    {
        var url = BuildManifestUrl(id, version, manifestType);
        var yaml = await url.GetStringAsync(cancellationToken: cancellationToken);

        return _deserializer.Deserialize<TManifest>(yaml);
    }

    private static Url BuildManifestUrl(string id, string version, string? manifestType = null)
    {
        string filename = manifestType == null
            ? $"{id}.yaml"
            : $"{id}.{manifestType}.yaml";

        return "https://raw.githubusercontent.com/microsoft/winget-pkgs/master/manifests"
            .AppendPathSegments(char.ToLower(id[0]))
            .AppendPathSegments(id.Split('.'))
            .AppendPathSegments(version, filename);
    }
}
