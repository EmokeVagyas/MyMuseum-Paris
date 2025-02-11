using Newtonsoft.Json;
using System.Globalization;

namespace Backend.Domain.Entities
{
    public class MonthDayJsonConverter : JsonConverter<DateOnly>
    {
        private const string DateFormat = "MM-dd";

        public override DateOnly ReadJson(JsonReader reader, Type objectType, DateOnly existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            string? dateString = reader.Value?.ToString();
            // Should we check if the destination field type is nullable?
            // A: Yes, we should check if the destination field type is nullable.
            // How to check it? A: We can check it by using the `Nullable.GetUnderlyingType` method.
            
            if (string.IsNullOrWhiteSpace(dateString))
            {
                if (objectType == typeof(DateOnly?))
                {
                    return default;
                }

                throw new JsonSerializationException("Invalid date format");
            }

            return DateOnly.ParseExact(dateString, DateFormat);
        }

        public override void WriteJson(JsonWriter writer, DateOnly value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString(DateFormat));
        }
    }

    public class DateOnlyJsonConverter : JsonConverter
    {
        private const string DateFormat = "MM-dd";

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            if (value is DateOnly date)
            {
                writer.WriteValue(date.ToString(DateFormat, CultureInfo.InvariantCulture));
            }
            else
            {
                writer.WriteNull();
            }
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            if (reader.Value is null || string.IsNullOrWhiteSpace(reader.Value.ToString()))
            {
                // ✅ Correctly handle `null` values for `DateOnly?`
                return objectType == typeof(DateOnly?) ? (DateOnly?)null : default(DateOnly);
            }

            if (DateOnly.TryParseExact(reader.Value.ToString(), DateFormat, CultureInfo.InvariantCulture, DateTimeStyles.None, out var date))
            {
                return date;
            }

            throw new JsonSerializationException($"Invalid date format: {reader.Value}");
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DateOnly) || objectType == typeof(DateOnly?);
        }
    }
}
