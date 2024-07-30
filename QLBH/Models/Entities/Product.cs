using QLBH.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLBH.Models
{
    public class Product
    {
        [Key]
        public int PROD_CODE{ get; set; }

        public string? PROD_NAME {  get; set; }

        public float UNITPRICE {  get; set; }
        
        public int STOCK_QTY {  get; set; } 

        public DateTime? UPDATE_DATE { get; set; }
        
        public string? UPDATER {  get; set; }

        public int WH_CODE { get; set; }

        //public ICollection<Warehouse>? Warehouse { get; set; }

        public ICollection<ORDER_DETAILS>? Orderdetails { get; set; }

        /* [ForeignKey("WH_CODE")]
         public Warehouse? Warehouse { get; set; }*/
    }   

}
