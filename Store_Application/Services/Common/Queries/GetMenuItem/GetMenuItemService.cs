using Microsoft.EntityFrameworkCore;
using Store_Application.Interface.Context;
using Store_Common.Dto;

namespace Store_Application.Services.Common.Queries.GetMenuItem
{
    public class GetMenuItemService : IGetMenuItemService
    {
        private readonly IDataBaseContext _context;
        public GetMenuItemService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<MenuItemDto>> Execute()
        {
            var catecory = _context.Categories.Include(p => p.SubCategories)
                 .Where(p => p.ParentCategoryId == null)
                 .ToList()
                 .Select(p => new MenuItemDto
                 {
                     CatId = p.Id,
                     Name = p.Name,
                     Child = p.SubCategories.ToList().Select(c => new MenuItemDto
                     {
                         CatId = c.Id,
                         Name = c.Name,
                     }).ToList(),
                 }).ToList();
            return new ResultDto<List<MenuItemDto>>
            {
                Data = catecory,
                IsSuccess = true
            };
        }
    }
}
