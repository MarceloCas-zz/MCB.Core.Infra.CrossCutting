using System.Text.Json;

namespace MCB.Core.Infra.CrossCutting.Serialization
{
    public static class ExtensionMethods
    {
        // Fields
        private static JsonSerializerOptions _jsonSerializerOptions = new JsonSerializerOptions(
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            }
        );

        private static Newtonsoft.Json.Schema.Generation.JSchemaGenerator _jSchemaGenerator = new();

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
}
