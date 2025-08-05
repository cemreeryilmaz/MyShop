using MediatR;
using MyShop.Order.Application.Features.MediatR.Queries.OrderingQueries;
using MyShop.Order.Application.Features.MediatR.Results.OrderingResults;
using MyShop.Order.Application.Interfaces;
using MyShop.Order.Domain.Entities;

namespace MyShop.Order.Application.Features.MediatR.Handlers.OrderingHandlers
{
    public class GetOrderingQueryHandler : IRequestHandler<GetOrderingQuery, List<GetOrderingQueryResult>>
    {
        IRepository<Ordering> _repository;

        public GetOrderingQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetOrderingQueryResult>> Handle(GetOrderingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetOrderingQueryResult
            {
                OrderingId = x.OrderingId,
                OrderDate = x.OrderDate,
                TotalPrice = x.TotalPrice,
                UserId = x.UserId
            }).ToList();
        }
    }
}
