using QLBH.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLBH.Models
{
    public class Orders
    {
        [Key]
        public int ORDER_NO {  get; set; } 
        
        public DateTime ORDER_DATE { get; set; }

        public int DEPT_CODE { get; set; } 

        public int CUST_CODE { get; set; } 
        
        public int CUST_SUB_NO {  get; set; }

        public int EMP_CODE { get; set; } 
       
        public DateTime REQUIRED_DATE {  get; set; }
        
        public int CUSTORDER_NO {  get; set; }

        public int WH_CODE { get; set; } 

        public int CMP_TAX { get; set; } 

        public string? SLIP_COMMENT { get; set; } 
        
        public DateTime UPDATE_DATE { get; set; }
        
        public string? UPDATER {  get; set; }

        public ICollection<ORDER_DETAILS>? OrderDetails { get; set; }

        public Customer? Customer { get; set; }

        public Warehouse? Warehouse { get; set; }

        public Employee? Employee { get; set; }

        public Department? Department { get; set; }


    }
}
