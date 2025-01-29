using Newtonsoft.Json;
using System.Net.Http.Json;

namespace Backend.Domain.Entities
{
    public class MuseumSchedule
    {
        public int MuseumId { get; set; }

        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly OpeningHour { get; set; }

        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        public TimeOnly ClosingHour { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
    }

    public class TimeOnlyJsonConverter : JsonConverter<TimeOnly>
    {
        private const string TimeFormat = "HH:mm"; // ISO 8601 time format

        public override void WriteJson(JsonWriter writer, TimeOnly value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString(TimeFormat));
        }

        public override TimeOnly ReadJson(JsonReader reader, Type objectType, TimeOnly existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return TimeOnly.ParseExact((string)reader.Value, TimeFormat);
        }
    }
}

