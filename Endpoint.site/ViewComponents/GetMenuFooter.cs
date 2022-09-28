using Microsoft.AspNetCore.Mvc;
using Store_Application.Services.Common.Queries.GetMenuItem;

namespace Endpoint.site.ViewComponents
{
    public class GetMenuFooter : ViewComponent
    {
        private readonly IGetMenuItemService _getMenuItemService;

        public GetMenuFooter(IGetMenuItemService getMenuItemService)
        {
            _getMenuItemService = getMenuItemService;
        }

        public IViewComponentResult Invoke()
        {
            var menuitem = _getMenuItemService.Execute();
            return View(viewName: "GetMenuFooter", menuitem.Data);
        }
    }
}
