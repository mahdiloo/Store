using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store_Application.Services.Fainances.Queries.GetRequestPayForAdmin;
using Microsoft.AspNetCore.Mvc;
using Store_Common;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area(AreasName.Admin)]
    public class RequestPayController : Controller
    {
        private readonly IGetRequestPayForAdminService _getRequestPayForAdminService;
        public RequestPayController(IGetRequestPayForAdminService getRequestPayForAdminService)
        {
            _getRequestPayForAdminService = getRequestPayForAdminService;
        }
        public IActionResult Index(string serchkey)
        {
            return View(_getRequestPayForAdminService.Execute(serchkey).Data);
        }
    }
}
