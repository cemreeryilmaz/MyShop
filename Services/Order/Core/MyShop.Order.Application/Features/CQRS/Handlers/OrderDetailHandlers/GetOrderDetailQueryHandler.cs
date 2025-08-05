using MyShop.Order.Application.Features.CQRS.Results.OrderDetailsResults;
using MyShop.Order.Application.Interfaces;
using MyShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailQueryHandler
    {
        IRepository<OrderDetail> _repository;
        public GetOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetOrderDetailQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderDetailQueryResult
            {
                OrderDetailId = x.OrderDetailId,
                Amount = x.Amount,
                Name = x.Name,
                OrderingId = x.OrderingId,
                Price = x.Price,
                ProductId = x.ProductId,
                TotalPrice = x.TotalPrice
            }).ToList();
        }
    }
}
