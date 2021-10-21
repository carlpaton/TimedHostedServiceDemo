using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TimedHostedService.Worker.Domain.Services
{
    public class EventDto
    {
        public int Id { get; set; }

        [JsonPropertyName("event_type")]
        public string EventType { get; set; }

        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        [JsonPropertyName("date_utc")]
        public DateTime DateUtc { get; set; }

        public List<ItemDto> Items { get; set; }
    }
}
