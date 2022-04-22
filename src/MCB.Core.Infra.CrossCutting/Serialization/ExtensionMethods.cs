using System.Text.Json;

namespace MCB.Core.Infra.CrossCutting.Serialization
{
    public static class ExtensionMethods
    {
        // Fields
        private static JsonSerializerOptions _jsonSerializerOptions;
        private static Newtonsoft.Json.Schema.Generation.JSchemaGenerator _jSchemaGenerator;

        // Constructors
        static ExtensionMethods()
        {
            _jsonSerializerOptions = new JsonSerializerOptions(new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            _jSchemaGenerator = new Newtonsoft.Json.Schema.Generation.JSchemaGenerator();
        }

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
