using System.ComponentModel.DataAnnotations;

namespace QLBH.DTO
{
    public class ProductDTO
    {
        [Key]
        public int? PROD_CODE { get; set; }

        public string? SEARCHVALUE { get; set; }

        public float? UNITPRICE { get; set; }

        public int? STOCK_QTY { get; set; }

        public int? WH_CODE { get; set; }


    }
}
