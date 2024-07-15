using System.ComponentModel.DataAnnotations;

namespace QLBH.Models
{
    public class Product
    {
        [Key]
        public int PROD_CODE{ get; set; }

        public string? PROD_NAME {  get; set; }

        public decimal? UNITPRICE {  get; set; }
        
        public int STOCK_QTY {  get; set; } 

        public DateTime UPDATE_DATE { get; set; }
        
        public string? UPDATER {  get; set; }

        public int? WH_CODE { get; set; }
    }   

}
