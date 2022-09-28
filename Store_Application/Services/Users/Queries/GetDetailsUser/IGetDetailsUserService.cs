using Store_Application.Interface.Context;
using Store_Application.Services.Users.Queries.GetUsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Application.Services.Users.Queries.GetDetailsUser
{
    public interface IGetDetailsUserService
    {
        GetUserDto Execute(long Id);
    }
    public class GetDetailsUserService : IGetDetailsUserService
    {
        private readonly IDataBaseContext _context;
        public GetDetailsUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public GetUserDto Execute(long Id)
        {
            var users = _context.Users.Find(Id);
            return  new GetUserDto
            {
                
                IsActive = users.IsActive,
                Email = users.Email,
                FullName = users.FullName,
                Id = users.Id,
            };
        }
    }
}
