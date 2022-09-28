using Microsoft.AspNetCore.Http;

namespace Store_Application.Services.Product.Commands.EditProduct
{
    public class RequestEditProductDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public long CategoryId { get; set; }
        public bool Displayed { get; set; }

        public List<IFormFile> Images { get; set; }
        public List<EditProduct_Features> Features { get; set; }
    }
}
