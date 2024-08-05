using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace QLBH.DTO
{
    public class CustomerRequest
    {
        [JsonPropertyName("cust_name")]
        public string? CUST_NAME { get; set; }

        [JsonPropertyName("address")]
        [MaxLength(255)]
        [MinLength(0)]
        public string? ADDRESS { get; set; }


        [JsonPropertyName("phone")]
        public string? PHONE {  get; set; }

        [JsonPropertyName("email")]
        public string? EMAIL { get; set; }

    }
}
