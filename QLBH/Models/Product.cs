namespace QLBH.Models
{
    public class Product
    {
        public int Prod_code { get; set; }

        public string Prod_name {  get; set; }  

        public float UnitPrice {  get; set; }
        
        public int Stock_QTY {  get; set; } 

        public DateTime Update_date { get; set; }
        
        public string Updater {  get; set; }    
    }   

}
