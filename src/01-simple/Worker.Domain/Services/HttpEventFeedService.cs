using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Worker.Domain.Services
{
    public class HttpEventFeedService : IEventFeedService
    {
        private readonly HttpClient _client;
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        public HttpEventFeedService(HttpClient client)
        {
            _client = client;
            _client.BaseAddress = new Uri("http://localhost:3331");

            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        ///<inheritdoc/>
        public async Task<IEnumerable<EventDto>> GetEventsAsync(long watermark)
        {
            var response = await _client
                .GetAsync($"/events?id_gte={watermark}");

            response.EnsureSuccessStatusCode();

            return await response
                .Content
                .ReadFromJsonAsync<List<EventDto>>(_jsonSerializerOptions);
        }
    }
}
