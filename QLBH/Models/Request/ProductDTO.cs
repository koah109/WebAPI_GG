using System.ComponentModel.DataAnnotations;

namespace QLBH.DTO
{
    public class ProductDTO
    {

        public string? PROD_NAME { get; set; }

        public float? UNITPRICE { get; set; }

        public int? STOCK_QTY { get; set; }

        public int? WH_CODE { get; set; }


    }
}
