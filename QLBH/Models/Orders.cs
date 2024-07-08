namespace QLBH.Models
{
    public class Orders
    {
        public int Order_no {  get; set; }
        
        public DateTime Order_date { get; set; }
        
        public int Dept_code {  get; set; }
        
        public int Cust_code {  get; set; }
        
        public int Cust_sub_no {  get; set; }
        
        public int Emp_code {  get; set; }
        
        public DateTime Required_date {  get; set; }
        
        public int Custorder_no {  get; set; }
        

        public int WH_code { get; set; }

        public int CMP_tax { get; set; }
        
        public int Slip_comment {  get; set; }
        
        public DateTime Update_date { get; set; }
        
        public string Updater {  get; set; }    
    }
}
