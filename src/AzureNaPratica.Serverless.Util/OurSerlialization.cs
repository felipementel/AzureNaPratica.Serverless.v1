using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AzureNaPratica.Serverless.Util
{
    [ExcludeFromCodeCoverage]
    public static class OurSerlialization
    {
        public static string Serializer<TEntity>(TEntity entity)
        {
            return System.Text.Json.JsonSerializer.Serialize<TEntity>(entity,
                new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true
                });
        }

        public static TEntity Deserializer<TEntity>(string value)
        {
            return System.Text.Json.JsonSerializer.Deserialize<TEntity>(value,
                new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true,
                    PropertyNameCaseInsensitive = true,
                    Converters =
                    {
                        new DateTimeOffsetJsonConverter()
                    }
                });
        }
        private class DateTimeOffsetJsonConverter : JsonConverter<DateTimeOffset>
        {
            public override DateTimeOffset Read(
                ref Utf8JsonReader reader,
                Type typeToConvert,
                JsonSerializerOptions options) =>
                    DateTimeOffset.ParseExact(reader.GetString(),
                        "dd/MM/yyyy", CultureInfo.InvariantCulture);

            public override void Write(
                Utf8JsonWriter writer,
                DateTimeOffset dateTimeValue,
                JsonSerializerOptions options) =>
                    writer.WriteStringValue(dateTimeValue.ToString(
                        "dd/MM/yyyy", CultureInfo.InvariantCulture));
        }
    }
}
