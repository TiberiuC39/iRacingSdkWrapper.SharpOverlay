using System;
using System.Text.Json;

namespace iRacingSdkWrapper.Utilities
{
    public class SessionTimeJsonConverter : JsonNumericConverter
    {
        public override double Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            try
            {
                double result = base.Read(ref reader, typeToConvert, options);

                return result;
            }
            catch (JsonException ex)
            {
                return 9999;
            }

        }
    }
}
