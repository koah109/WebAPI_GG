namespace QLBH.Models.Response
{
    public class BaseResultPagingResponse<T>
    {
        public int Status { get; set; }

        public string? Message { get; set; }

        public int? Page { get; set; }

        public int Total { get; set; }

        public List<T>? Items { get; set; }
    }
}
