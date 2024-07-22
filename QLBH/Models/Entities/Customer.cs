using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QLBH.Models
{
    public class Customer
    {
        [Key]
        public int CUST_CODE { get; set; }

        //[JsonPropertyName("CUST_NAME123")]
        public string? CUST_NAME { get; set; }

        public string? ADDRESS { get;   set;}

        public string? PHONE {  get; set;}  

        public string? EMAIL {  get; set;}
        
        public DateTime UPDATE_DATE { get; set; }

        public string? UPDATER { get; set; }
    }
}
