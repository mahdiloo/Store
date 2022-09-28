namespace Store_Application.Services.Product.Queries.GetProductForAdmin
{
    public class ProductForAdminDto
    {
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public List<ProductForAdminListDto> Products { get; set; }
    }
}
