using MediatR;
using ShoppingCart.Order.Application.Features.Mediator.Commands;
using ShoppingCart.Order.Application.Interfaces;
using ShoppingCart.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Order.Application.Features.Mediator.Handlers
{
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public CreateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateOrderingCommand command, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Ordering
            {
                UserId = command.UserId,
                TotalPrice = command.TotalPrice,
                OrderDate = command.OrderDate
            });
        }
    }
}