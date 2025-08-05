using MyShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MyShop.Order.Application.Interfaces;
using MyShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class CreateOrderDetailCommandHandler
    {
        IRepository<OrderDetail> _repository;
        public CreateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateOrderDetailCommand command)
        {
            await _repository.CreateAsync(new OrderDetail
            {
                Amount = command.Amount,
                Name = command.Name,
                OrderingId = command.OrderingId,
                ProductId = command.ProductId,
                Price = command.Price,
                TotalPrice = command.TotalPrice,
            });
        }
    }
}
