using Microsoft.AspNetCore.Mvc;
using Store_Application.Services.Fainances.Queries.GetPayDetailService;
using Store_Common;
using Store_Domain.Entities.Orders;

namespace Endpoint.site.Areas.Admin.Controllers
{
    [Area(AreasName.Admin)]
    public class PayDetailController : Controller
    {
        private readonly IGetPayDetailService _getPayDetailService;
        public PayDetailController(IGetPayDetailService getPayDetailService)
        {
            _getPayDetailService = getPayDetailService;
        }
        public IActionResult Index(long Id)
        {         
            return View(_getPayDetailService.Execute(Id));
        }
    }
}
