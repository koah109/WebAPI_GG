using QLBH.Models;
using QLBH.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace QLBH.DTO
{
    public class OrderRequest
    {
        [JsonPropertyName("dept_code")]
        public int DEPT_CODE { get; set; } = 1;


        [JsonPropertyName("cust_code")]
        public int CUST_CODE { get; set; } = 6;


        [JsonPropertyName("emp_code")]
        public int EMP_CODE { get; set; } = 4;


        [JsonPropertyName("wh_code")]
        public int WH_CODE { get; set; } = 1;


        [JsonPropertyName("cmp_tax")]
        public int CMP_TAX { get; set; } = 10;


        [JsonPropertyName("slip_comment")]
        public string? SLIP_COMMENT { get; set; } = "quá tốt";


        [JsonPropertyName("orderdetails")]
        public  List<OrderDetailRequest>? OrderDetails { get; set; }
       
    }
}
