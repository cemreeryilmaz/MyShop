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
    public class UpdateOrderDetailCommandHandler
    {
        IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var values = await _repository.GetByIdAsync(command.OrderDetailId);
            values.Name = command.Name;
            values.OrderingId = command.OrderingId;
            values.ProductId = command.ProductId;
            values.Price = command.Price;
            values.TotalPrice = command.TotalPrice;
            values.Amount = command.Amount;
            await _repository.UpdateAsync(values);
        }
    }
}
