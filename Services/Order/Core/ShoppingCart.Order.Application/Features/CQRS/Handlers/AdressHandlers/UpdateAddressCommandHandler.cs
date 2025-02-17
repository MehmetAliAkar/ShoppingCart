using ShoppingCart.Order.Application.Features.CQRS.Commands.AddressCommands;
using ShoppingCart.Order.Application.Interfaces;
using ShoppingCart.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Order.Application.Features.CQRS.Handlers.AdressHandlers
{
    public class UpdateAddressCommandHandler
    {
        private readonly IRepository<Address> _repository;

        public UpdateAddressCommandHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAddressCommand command)
        {
            var value = await _repository.GetByIdAsync(command.AddressId);
            value.Detail = command.Detail;
            value.UserId = command.UserId;
            value.District = command.District;
            value.City = command.City;
            await _repository.UpdateAsync(value);
        }
    }
}