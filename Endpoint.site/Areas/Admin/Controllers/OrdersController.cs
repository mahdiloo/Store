using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store_Application.Services.Orders.Queries.GetOrdersForAdmin;
using Store_Domain.Entities.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Store_Common;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area(AreasName.Admin)]
    [Authorize(Roles ="Admin,Operator")]
    public class OrdersController : Controller
    {
        private readonly IGetOrdersForAdminService _getOrdersForAdminService;
        public OrdersController(IGetOrdersForAdminService getOrdersForAdminService)
        {
            _getOrdersForAdminService = getOrdersForAdminService;
        }
        public IActionResult Index(OrderState orderState,string serchkey)
        {
            TempData["orderState"] = orderState;
            return View(_getOrdersForAdminService.Execute(orderState, serchkey).Data);
        }
    }
}
