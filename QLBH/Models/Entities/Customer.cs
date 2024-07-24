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

        public string? ADDRESS { get;   set;}

        public string? PHONE {  get; set;}  

        public string? EMAIL {  get; set;}
        
        public DateTime UPDATE_DATE { get; set; }

        public string? UPDATER { get; set; }
    }
}
