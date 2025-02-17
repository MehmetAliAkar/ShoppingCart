using ShoppingCart.Order.Application.Features.CQRS.Commands.AddressCommands;
using ShoppingCart.Order.Application.Interfaces;
using ShoppingCart.Order.Domain.Entities;

namespace ShoppingCart.Order.Application.Features.CQRS.Handlers.AdressHandlers
{
    public class CreateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public CreateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateAddressCommand createAddressCommand)
        {
            await _repository.CreateAsync(new Address
            {
                City = createAddressCommand.City,
                Detail = createAddressCommand.Detail,
                District = createAddressCommand.District,
                UserId = createAddressCommand.UserId,
            });
        }
    }
}