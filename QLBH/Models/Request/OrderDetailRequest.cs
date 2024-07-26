using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QLBH.Models
{
    public class OrderDetailRequest
    {
        [JsonPropertyName("prod_code")]
        public int PROD_CODE { get; set; }

        [JsonPropertyName("unitprice")]
        public float? UNITPRICE {  get; set; }


        [JsonPropertyName("quantity")]
        public int QUANTITY {  get; set; }


        [JsonPropertyName("cmp_tax_rate")]
        public float CMP_TAX_RATE {  get; set; }


        [JsonPropertyName("reserve_qty")]
        public int RESERVE_QTY {  get; set; }


        [JsonPropertyName("delivery_order_qty")]
        public int DELIVERY_ORDER_QTY { get; set; }


        [JsonPropertyName("delivered_qty")]
        public int DELIVERED_QTY { get; set; }


        [JsonPropertyName("complete_flg")]
        public int COMPLETE_FLG { get; set; }


        [JsonPropertyName("discount")]
        public float DISCOUNT {  get; set; }
    }
}
