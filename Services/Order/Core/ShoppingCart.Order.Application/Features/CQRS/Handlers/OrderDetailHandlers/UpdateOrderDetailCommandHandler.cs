using ShoppingCart.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using ShoppingCart.Order.Application.Interfaces;
using ShoppingCart.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderDetailCommand command)
        {
            var value = await _repository.GetByIdAsync(command.OrderDetailId);
            value.ProductName = command.ProductName;
            value.ProductPrice = command.ProductPrice;
            value.ProductTotalPrice = command.ProductTotalPrice;
            value.ProductId = command.ProductId;
            value.ProductAmount = command.ProductAmount;
            value.OrderingId = command.OrderingId;
            await _repository.UpdateAsync(value);
        }
    }
}