using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLBH.Models
{
    public class ORDER_DETAILS
    {
        
        public int ORDER_NO { get; set; }
        [Key]
        public int SO_ROW_NO {  get; set; }

        public int PROD_CODE { get; set; }

        public string? PROD_NAME { get; set; }

        public float UNITPRICE {  get; set; }

        public int QUANTITY {  get; set; }

        public float CMP_TAX_RATE {  get; set; }

        public int RESERVE_QTY {  get; set; }

        public int DELIVERY_ORDER_QTY { get; set; }

        public int DELIVERED_QTY { get; set; }

        public int COMPLETE_FLG { get; set; }

        public float DISCOUNT {  get; set; }

        public DateTime? DELIVERY_DATE {  get; set; }

        public DateTime? UPDATE_DATE { get; set; }

        public string? UPDATER {  get; set; }

        public Orders? Orders { get; set; }

        public Product? Product { get; set; }

/*        [ForeignKey("ORDER_NO")]
        public Orders? Orders { get; set; }


        [ForeignKey("PROD_CODE")]
        public Product? Product { get; set; }*/
    }
}
