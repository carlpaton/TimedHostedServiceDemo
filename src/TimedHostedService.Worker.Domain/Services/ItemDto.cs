using System.Text.Json.Serialization;

namespace TimedHostedService.Worker.Domain.Services
{
    public class ItemDto
    {
        public string Id { get; set; }

        public int Quantity { get; set; }

        [JsonPropertyName("unit_cost")]
        public decimal UnitCost { get; set; }
    }
}
