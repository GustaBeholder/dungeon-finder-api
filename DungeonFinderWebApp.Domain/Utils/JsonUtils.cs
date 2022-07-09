

using System.Text;
using System.Text.Json;

namespace DungeonFinderWebApp.Domain.Utils
{
    public static class JsonUtils
    {

        public static async Task<T> Deserializar<T>(HttpResponseMessage dados)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            };

            return JsonSerializer.Deserialize<T>(await dados.Content.ReadAsStringAsync(), options);
        }

        public static StringContent ObterStringContent(object dados)
        {
            return new StringContent(
                JsonSerializer.Serialize(dados),
                Encoding.UTF8,
                "application/json");
        }
    }
}
