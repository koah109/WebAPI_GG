using System.ComponentModel.DataAnnotations;

namespace QLBH.Models
{
    public class Order_Detail
    {
        [Key]
        public int Order_no { get; set; }

        public int So_row_no {  get; set; }

        public int Prod_code { get; set; }

        public string? Prod_name { get; set; }

        public float UnitPrice {  get; set; }

        public int Quantity {  get; set; }

        public int CMP_tax_rate {  get; set; }

        public int Reserve_QTY {  get; set; }

        public int Delivery_order_QTY { get; set; }

        public int Delivery_QTY { get; set; }

        public int Complete_FLG { get; set; }

        public float Discount {  get; set; }

        public DateTime Delivery_date {  get; set; }


        public DateTime Update_date { get; set; }

        public string? Updater {  get; set; }
    }
}
