using System.Text.Json;

namespace MoviesNsi.Domain.Common.Extensions;

public static class SerializerExtensions
{
    public static readonly JsonSerializerOptions DefaultOptions = new();

    public static readonly JsonSerializerOptions SettingsWebOptions = new(JsonSerializerDefaults.Web)
    {
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase
    };
    
    public static readonly JsonSerializerOptions SettingsHardwareOptions = new()
    {
        PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower
    };

    public static string Serialize(this object? json, JsonSerializerOptions settings) => JsonSerializer.Serialize(json, settings);

    public static T? Deserialize<T>(this string json, JsonSerializerOptions settings) => JsonSerializer.Deserialize<T>(json, settings);

    public static bool TryDeserializeJson<T>(this string obj, out T? result, JsonSerializerOptions settings)
    {
        try
        {
            result = Deserialize<T>(obj, settings);
            return true;
        }
        catch (Exception)
        {
            result = default;
            return false;
        }
    }
}