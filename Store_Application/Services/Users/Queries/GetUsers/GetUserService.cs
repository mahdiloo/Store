using Store_Application.Interface.Context;
using Store_Common;
using System.Linq;

namespace Store_Application.Services.Users.Queries.GetUsers
{
    public class GetUserService: IGetUserService
    {
        private readonly IDataBaseContext _context;
        public GetUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultGetUserDto Execute(RequestGetUserDto requestGetUserDto)
        {
            var users = _context.Users.AsQueryable();
            if(!string.IsNullOrWhiteSpace(requestGetUserDto.Searchkey))
            {
                users = users.Where(p => p.FullName.Contains(requestGetUserDto.Searchkey) || p.Email.Contains(requestGetUserDto.Searchkey));               
            }
            int rowscount = 0;
            var usersList = users.ToPaged(requestGetUserDto.Page, 20, out rowscount).Select(p => new GetUserDto
            {
                IsActive=p.IsActive,
                Email = p.Email,
                FullName = p.FullName,
                Id = p.Id,
            }).ToList();

            return new ResultGetUserDto
            {
                Rows = rowscount,
                users = usersList,
            };
        }
    }
}