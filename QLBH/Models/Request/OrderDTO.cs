using QLBH.Models;
using System.ComponentModel.DataAnnotations;

namespace QLBH.DTO
{
    public class OrderDTO
    {
        [Key]

        public int? SO_ROW_NO {  get; set; }
        public string?  PROD_NAME { get; set; }

        public int? QUANTITY {  get; set; }

        public float? PRICE {  get; set; }

        public DateTime DELIVERY_DATE { get; set; }
    }
}
