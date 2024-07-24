using QLBH.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLBH.Models
{
    public class Employee
    {
        [Key]
        public int EMP_CODE {  get; set; }

        public string? EMP_NAME {  get; set; }

        public string? POSITION {  get; set; }

        public DateTime HIRE_DATE { get; set; }

        public string? UPDATER {  get; set; }


    }
}
