using System.Text.Json;

namespace MCB.Core.Infra.CrossCutting.Serialization;

public static class ExtensionMethods
{
    // Fields
    private static readonly JsonSerializerOptions _jsonSerializerOptions = new(
        new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        }
    );

    private static readonly Newtonsoft.Json.Schema.Generation.JSchemaGenerator _jSchemaGenerator = new();

    // Public Methods
    public static string SerializeToJson(this object obj)
    {
        return JsonSerializer.Serialize(obj, _jsonSerializerOptions);
    }
    public static T? DeserializeFromJson<T>(this string json)
    {
        return JsonSerializer.Deserialize<T>(json, _jsonSerializerOptions);
    }
    public static string GenerateJsonSchema(this Type type)
    {
        return _jSchemaGenerator.Generate(type).ToString();
    }
    public static string GenerateJsonSchema(this object obj)
    {
        return GenerateJsonSchema(obj.GetType());
    }
}
