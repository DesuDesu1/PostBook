using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PostBook.IntegrationTests.Extensions
{
    public static class HttpContentExtensions
    {

        private static readonly JsonSerializerOptions defaultOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true,
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };

        public static async Task<T> ReadAsAsync<T>(this HttpContent content, JsonSerializerOptions options = null)
        {
            using (Stream contentStream = await content.ReadAsStreamAsync())
            {
                return await JsonSerializer.DeserializeAsync<T>(contentStream, options ?? defaultOptions);
            }
        }

    }
}
