using System.ComponentModel.DataAnnotations;

namespace QLBH.Models.Entities
{
    public class Warehouse
    {
        [Key]
        public int WH_CODE { get; set; }

        public string? WH_NAME { get; set; }

        public string? LOCATION { get; set; }
    }
}
