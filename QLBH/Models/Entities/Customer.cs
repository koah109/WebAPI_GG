using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QLBH.Models
{
    public class Customer
    {
        [Key]
        [JsonPropertyName("cust_code")]
        public int CUST_CODE { get; set; }


        [JsonPropertyName("cust_name")]
        public string? CUST_NAME { get; set; }


        [JsonPropertyName("address")]
        public string? ADDRESS { get;   set;}


        [JsonPropertyName("phone")]
        public string? PHONE {  get; set;}


        [JsonPropertyName("email")]
        public string? EMAIL {  get; set;}


        [JsonPropertyName("update_date")]
        public DateTime? UPDATE_DATE { get; set; }


        [JsonPropertyName("updater")]
        public string? UPDATER { get; set; }
    }
}
