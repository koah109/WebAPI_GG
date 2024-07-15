namespace QLBH.DTO
{
    public class CustomerDTO: PagingRequest
    {
        public string? searchValue { get; set; }

        public string? address { get; set; }

        public string? phone {  get; set; }

        public string? email { get; set; }

    }
}
