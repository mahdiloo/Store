using Store_Application.Interface.Context;
using Store_Common.Dto;

namespace Store_Application.Services.Common.Queries.GetSlider
{
    public class GetSliderService : IGetSliderService
    {
        private readonly IDataBaseContext _dataBaseContext;

        public GetSliderService(IDataBaseContext dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }
        public ResultDto<List<SliderDto>> Execute()
        {
            var sliders = _dataBaseContext.Sliders.OrderByDescending(p => p.Id).ToList().Select(
                p => new SliderDto
                {
                    Id=p.Id,
                    Link = p.Link,
                    Src = p.Src,
                }).ToList();
            return new ResultDto<List<SliderDto>>
            {
                Data = sliders,
                IsSuccess = true,
            };
 ;        }

        public ResultDto<SliderDto> ExecuteDetails(long Id)
        {
            var sliders = _dataBaseContext.Sliders.Where(p => p.Id == Id).FirstOrDefault();
            return new ResultDto<SliderDto>
            {
                Data = new SliderDto
                { Id= sliders .Id,
                Link= sliders.Link,
                Src= sliders.Src,
                },
                IsSuccess = true,
            };
        }
    }
}
