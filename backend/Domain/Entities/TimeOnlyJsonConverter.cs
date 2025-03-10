using Newtonsoft.Json;
using System;

namespace Backend.Domain.Entities
{
    public class TimeDayJsonConverter : JsonConverter<TimeOnly?>
    {
        private const string TimeFormat = "HH:mm";

        public override TimeOnly? ReadJson(JsonReader reader, Type objectType, TimeOnly? existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value?.ToString();

            if (string.IsNullOrWhiteSpace(value))
            {
                if (objectType == typeof(TimeOnly?))
                {
                    return default;
                }

                throw new JsonSerializationException("Invalid time format");
            }

            return TimeOnly.ParseExact(value, TimeFormat);
        }

        public override void WriteJson(JsonWriter writer, TimeOnly? value, JsonSerializer serializer)
        {
            writer.WriteValue(value?.ToString(TimeFormat));
        }
    }

    public class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
    {
        private const string TimeFormat = "HH:mm";

        public override void WriteJson(JsonWriter writer, TimeOnly value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString(TimeFormat));
        }

        public override TimeOnly ReadJson(JsonReader reader, Type objectType, TimeOnly existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var value = reader.Value?.ToString();

            if (string.IsNullOrWhiteSpace(value)) return default;

            return TimeOnly.ParseExact(value, TimeFormat);
        }
    }
}