using System.ComponentModel.DataAnnotations;

namespace QLBH.Models
{
    public class Employee
    {
        [Key]
        public int EMP_CODE {  get; set; }

        public string? EMP_NAME {  get; set; }

        public int DEPT_CODE {  get; set; }

        public string? POSITION {  get; set; }

        public DateTime HIRE_DATE { get; set; }

        public DateTime UPDATE_DATE {  get; set; }

        public string? UPDATER {  get; set; }

    }
}
