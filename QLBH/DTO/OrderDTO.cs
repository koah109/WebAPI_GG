using QLBH.Models;

namespace QLBH.DTO
{
    public class OrderDTO
    {
        public DateTime Required_date { get; set; }

        public string? CMP_tax {  get; set; }

        public string? Slip_comment {  get; set; }
    }
}
