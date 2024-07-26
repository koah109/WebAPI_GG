using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace QLBH.DTO
{
    public class ProductRequest
    {
        [JsonPropertyName("prod_name")]
        public string? PROD_NAME { get; set; }


        [JsonPropertyName("unitprice")]
        public float UNITPRICE { get; set; }


        [JsonPropertyName("stock_qty")]
        public int STOCK_QTY { get; set; }


        [JsonPropertyName("wh_code")]
        public int WH_CODE { get; set; }


    }
}
