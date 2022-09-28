using Store_Domain.Entities.HomePages;

namespace Store_Application.Services.Common.Queries.GetHomePageImages
{
    public class HomePageImagesDto
    {
        public long Id { get; set; }
        public string Src { get; set; }
        public string? Link { get; set; }
        public ImageLocation ImageLocation { get; set; }
    }
}
