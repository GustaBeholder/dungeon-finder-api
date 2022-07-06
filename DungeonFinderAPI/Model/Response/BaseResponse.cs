using System.Text.Json.Serialization;

namespace DungeonFinderAPI.Model.Response
{
    public class BaseResponse
    {
        [JsonPropertyName("errorCode")]
        public int ErrorCode { get; set; }
        [JsonPropertyName("errorMessage")]
        public string Message { get; set; }
    }
}
