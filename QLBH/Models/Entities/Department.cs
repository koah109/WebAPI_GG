using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLBH.Models.Entities
{
    public class Department
    {
        [Key]
        public int DEPT_CODE {  get; set; }

        public string? DEPT_NUMBER { get;set; }

        public string? ADDRESS {  get; set; }
    }
}
