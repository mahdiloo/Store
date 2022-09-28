using Microsoft.EntityFrameworkCore;
using Store_Application.Interface.Context;
using Store_Application.Services.Product.Queries.GetProductDetailForSite;
using Store_Application.Services.Users.Queries.GetDetailsUser;
using Store_Application.Services.Users.Queries.GetUsers;
using Store_Domain.Entities.Orders;
using Store_Domain.Entities.Products;
using Store_Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store_Application.Services.Fainances.Queries.GetPayDetailService
{
    public interface IGetPayDetailService
    {
        GetPayDetailDto Execute(long Id);
    }
    public class GetPayDetailService : IGetPayDetailService
    {
        private readonly IDataBaseContext _context;
        public GetPayDetailService(IDataBaseContext context)
        {
            _context = context;
        }
        public GetPayDetailDto Execute(long Id)
        {
            var Pays = _context.RequestPays.Include(p => p.Orders).ThenInclude(p => p.OrderDetails).ThenInclude(p => p.Product).Include(p=>p.User)
                .Where(p => p.Id == Id).FirstOrDefault();

            return new GetPayDetailDto
            {
                Id = Pays.Id,
                Guid = Pays.Guid,
                Amount = Pays.Amount,
                IsPay = Pays.IsPay,
                PayDate = Pays.PayDate,
                Authority = Pays.Authority,
                RefId = Pays.RefId,
                Address = Pays.Orders.Select(p => p.Address).FirstOrDefault(),
                order = Pays.Orders.Select(p => new OrderDetailsDto
                {
                    orderdetail = p.OrderDetails.ToList(),
                }).ToList(),

                UserName = Pays.User.FullName,
            };
        }
    }
    public class GetPayDetailDto
    {
        public long Id { get; set; }
        public Guid Guid { get; set; }
        public int Amount { get; set; }
        public bool IsPay { get; set; }
        public DateTime? PayDate { get; set; }
        public string Authority { get; set; }
        public long RefId { get; set; } = 0;
        public string Address { get; set; }
        public string UserName { get; set; }
        public List<OrderDetailsDto> order { get; set; }
    }
    public class OrderDetailsDto
    {
        public List<OrderDetail> orderdetail { get; set; }
    }
}

