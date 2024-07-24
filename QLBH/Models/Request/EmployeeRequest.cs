using System.Text.Json.Serialization;

namespace QLBH.DTO
{
    public class EmployeeRequest
    {
        [JsonPropertyName("EMP_NAME")]
        public string? EMP_NAME {  get; set; }


        [JsonPropertyName("position")]
        public string? POSITION { get; set; }


        [JsonPropertyName("hire_date")]
        public DateTime? HIRE_DATE { get; set; }
    }
}
