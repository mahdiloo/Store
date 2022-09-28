using Store_Application.Interface.Context;
using Store_Application.Services.Common.Queries.GetSlider;
using Store_Common.Dto;

namespace Store_Application.Services.Common.Queries.GetHomePageImages
{
    public class GetHomePageImagesService : IGetHomePageImagesService
    {
        private readonly IDataBaseContext _context;
        public GetHomePageImagesService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<HomePageImagesDto>> Execute()
        {
            var images = _context.HomePageImages.OrderByDescending(p => p.Id)
                .Select(p => new HomePageImagesDto
                {
                    Id = p.Id,
                    ImageLocation = p.ImageLocation,
                    Link = p.link,
                    Src = p.Src,
                }).ToList();
            return new ResultDto<List<HomePageImagesDto>>()
            {
                Data = images,
                IsSuccess = true,
            };
        }

        public ResultDto<HomePageImagesDto> ExecuteDetails(long Id)
        {
            var HomePageImages = _context.HomePageImages.Where(p => p.Id == Id).FirstOrDefault();
            return new ResultDto<HomePageImagesDto>
            {
                Data = new HomePageImagesDto
                {
                    Id = HomePageImages.Id,
                    Link = HomePageImages.link,
                    Src = HomePageImages.Src,
                },
                IsSuccess = true,
            };
        }

       
    }
}
