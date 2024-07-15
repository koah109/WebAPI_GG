using System.ComponentModel.DataAnnotations;

namespace QLBH.Models
{
    public class Bill
    {
        [Key]
        public int Id { get; set; }

        public int Order_Id {  get; set; }

        public Orders? Order { get; set; }

        public decimal Price { get; set; }

        public DateTime Update_date { get; set; }
    }
}
