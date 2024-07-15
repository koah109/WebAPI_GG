using System.ComponentModel.DataAnnotations;

namespace QLBH.Models
{
    public class Employee
    {
        [Key]
        public int Emp_code {  get; set; }

        public string? Emp_name {  get; set; }

        public int Dept_code {  get; set; }

        public string? Position {  get; set; }

        public DateTime Hire_date { get; set; }

        public DateTime Update_date {  get; set; }

        public string? Updater {  get; set; }

    }
}
