using MediatR;
using ShoppingCart.Order.Application.Features.Mediator.Commands;
using ShoppingCart.Order.Application.Interfaces;
using ShoppingCart.Order.Domain.Entities;

namespace ShoppingCart.Order.Application.Features.Mediator.Handlers
{
    public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public UpdateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateOrderingCommand command, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(command.OrderingId);
            value.OrderDate = command.OrderDate;
            value.UserId = command.UserId;
            value.TotalPrice = command.TotalPrice;
            await _repository.UpdateAsync(value);
        }
    }
}