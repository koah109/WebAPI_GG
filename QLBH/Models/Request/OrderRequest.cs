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
        public int DEPT_CODE { get; set; }


        [JsonPropertyName("cust_code")]
        public int CUST_CODE { get; set; }


        [JsonPropertyName("emp_code")]
        public int EMP_CODE { get; set; }


        [JsonPropertyName("wh_code")]
        public int WH_CODE { get; set; }


        [JsonPropertyName("cmp_tax")]
        public int CMP_TAX { get; set; }


        [JsonPropertyName("slip_comment")]
        public string? SLIP_COMMENT { get; set; }


        [JsonPropertyName("orderdetails")]
        public  List<OrderDetailRequest>? OrderDetails { get; set; }
       
    }
}
