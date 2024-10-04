using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace iRacingSdkWrapper.Utilities
{
    public class JsonNumericConverter : JsonConverter<double>
    {
        private readonly string _pattern;
        private readonly Regex _regex;

        public JsonNumericConverter()
        {
            _pattern = @"(\d+\.?\d*)";
            _regex = new Regex(_pattern);
        }

        public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string value = string.Empty;

            if (reader.TokenType == JsonTokenType.Number)
            {
                value = reader.ValueSequence.ToString();
            }
            else
            {
                value = reader.GetString();
            }

            var regExMatch = _regex.Match(value);

            if (!regExMatch.Success)
            {
                throw new JsonException($"Value '{value}' is not a number");
            }

            double extractedValue = double.Parse(regExMatch.Value);

            return extractedValue;
        }

        public override void Write(Utf8JsonWriter writer, double value, JsonSerializerOptions options)
        {
            writer.WriteNumberValue(value);
        }

    }
}
