using ShoppingCart.Order.Application.Features.CQRS.Queries.AddressQueries;
using ShoppingCart.Order.Application.Features.CQRS.Results.AddressResults;
using ShoppingCart.Order.Application.Interfaces;
using ShoppingCart.Order.Domain.Entities;

namespace ShoppingCart.Order.Application.Features.CQRS.Handlers.AdressHandlers
{
    public class GetAddressByIdQueryHandler
    {
        private readonly IRepository<Address> _addressRepository;

        public GetAddressByIdQueryHandler(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery query)
        {
            var values = await _addressRepository.GetByIdAsync(query.Id);
            return new GetAddressByIdQueryResult
            {
                AddressId = values.AddressId,
                Detail = values.Detail,
                City = values.City,
                District = values.District,
                UserId = values.UserId
            };
        }
    }
}