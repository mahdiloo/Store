using Microsoft.AspNetCore.Http;
using Store_Application.Services.Product.Commands.AddNewProduct;

namespace Store_Application.Services.Product.Queries.GetProductForAdmin
{
    public class ProductForAdminListDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }
        public List<string> Images { get; set; }
        public List<ProductForAdminList_Features> Features { get; set; }
    }
}
