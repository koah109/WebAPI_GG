namespace QLBH.DTO
{
    public class ProductDTO : PagingRequest
    {
        public string? SEARCHVALUE { get; set; }

        public decimal? UNITPRICE { get; set; }

        public int? STOCK_QTY { get; set; }


    }
}
