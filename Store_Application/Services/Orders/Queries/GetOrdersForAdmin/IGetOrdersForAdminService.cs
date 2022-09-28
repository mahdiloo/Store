using Store_Application.Interface.Context;
using Store_Common.Dto;
using Store_Domain.Entities.Orders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Store_Application.Services.Users.Queries.GetUsers;
using Store_Domain.Entities.Users;
using Store_Common;

namespace Store_Application.Services.Orders.Queries.GetOrdersForAdmin
{
    public interface IGetOrdersForAdminService
    {
        ResultDto<List<OrdersDto>> Execute(OrderState orderState, string Searchkey);
    }

    public class GetOrdersForAdminService : IGetOrdersForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetOrdersForAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<OrdersDto>> Execute(OrderState orderState,string Searchkey)
        {       
            var orders = _context.Orders
            .Include(p => p.OrderDetails)
            .Where(p => p.OrderState == orderState)
             .OrderByDescending(p => p.Id)
             .ToList().Select(p => new OrdersDto
            {
                InsetTime = p.InsertTime,
                OrderId = p.Id,
                OrderState = p.OrderState,
                ProductCount = p.OrderDetails.Count(),
                RequestId = p.RequestPayId,
                UserId = p.UserId,
            }).ToList();

            if (!string.IsNullOrWhiteSpace(Searchkey))
            {
                orders = orders.Where(p => p.RequestId==long.Parse(Searchkey)).ToList();
            }

            return new ResultDto<List<OrdersDto>>()
            {
                Data = orders,
                IsSuccess = true,
            };
        }
    }
    public class OrdersDto
    {
        public long OrderId { get; set; }
        public DateTime InsetTime { get; set; }
        public long RequestId { get; set; }
        public long UserId { get; set; }
        public OrderState OrderState { get; set; }
        public int ProductCount { get; set; }

    }
}
