using System.Text.Json;
using System.Text.RegularExpressions;
using System;
using System.Text.Json.Serialization;

namespace iRacingSdkWrapper.Utilities
{
    public class JsonIntConverter : JsonConverter<int>
    {
        private readonly string _pattern;
        private readonly Regex _regex;

        public JsonIntConverter()
        {
            _pattern = @"(\d+)";
            _regex = new Regex(_pattern);
        }

        public override int Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string value = string.Empty;

            if (reader.TokenType == JsonTokenType.Number)
            {
                value = reader.ValueSequence.ToString();
            }
            else
            {
                value = reader.GetString();

                if (string.IsNullOrEmpty(value))
                {
                    return default;
                }
            }

            var regExMatch = _regex.Match(value);

            if (!regExMatch.Success)
            {
                throw new JsonException($"Value '{value}' is not a number");
            }

            int extractedValue = int.Parse(regExMatch.Value);

            return extractedValue;
        }

        public override void Write(Utf8JsonWriter writer, int value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value);
        }
    }
}
