using Microsoft.AspNetCore.Mvc;
using Store_Application.Services.Users.Queries.GetDetailsUser;
using Store_Common;

namespace Endpoint.site.Areas.Admin.Controllers
{
    [Area(AreasName.Admin)]
    public class GetDetailsUserController : Controller
    {
        private readonly IGetDetailsUserService _getDetailsUserService;

        public GetDetailsUserController(IGetDetailsUserService getDetailsUserService)
        {
            _getDetailsUserService = getDetailsUserService;
        }
        public IActionResult Index(long Id)
        {
            return View(_getDetailsUserService.Execute(Id));
        }
    }
}
