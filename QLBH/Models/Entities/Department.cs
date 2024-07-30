using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QLBH.Models.Entities
{
    public class Department
    {
        [Key]
        public int DEPT_CODE {  get; set; }

        public string? DEPT_NAME { get;set; }

        public string? ADDRESS {  get; set; }

        public ICollection<Orders>? Orders { get; set; }
    }
}
