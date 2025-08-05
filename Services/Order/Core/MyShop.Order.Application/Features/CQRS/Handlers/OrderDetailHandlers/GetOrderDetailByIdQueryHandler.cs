using MyShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MyShop.Order.Application.Features.CQRS.Results.OrderDetailsResults;
using MyShop.Order.Application.Interfaces;
using MyShop.Order.Domain.Entities;

namespace MyShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDetailByIdQueryHandler
    {
        IRepository<OrderDetail> _repository;

        public GetOrderDetailByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResult
            {
               OrderDetailId = values.OrderDetailId,
               Amount = values.Amount,
               ProductId = values.ProductId,
               Name = values.Name,
               OrderingId = values.OrderingId,
               Price = values.Price,
               TotalPrice = values.TotalPrice
            };
        }
    }
}
