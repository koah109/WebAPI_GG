using System.ComponentModel.DataAnnotations;

namespace QLBH.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        public string? Username {  get; set; }

        public string? Password { get; set; }

        public string? Fullname {  get; set; }


    }
}
