namespace QLBH.Models
{
    public class Customer
    {
        public int Cust_code { get; set; }
        public string Cust_name { get; set; }

        public string Address { get;   set;}

        public string Phone {  get; set;}  

        public string Email {  get; set;}
        
        public DateTime Update_date { get; set; }

        public string Updater { get; set; }
    }
}
