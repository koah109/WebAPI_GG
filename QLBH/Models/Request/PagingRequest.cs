using System.Text.Json.Serialization;

namespace QLBH.DTO
{
    public class PagingRequest
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }  
    }
}
