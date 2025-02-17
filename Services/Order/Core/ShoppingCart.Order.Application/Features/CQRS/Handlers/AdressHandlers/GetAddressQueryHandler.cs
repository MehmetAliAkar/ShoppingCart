using ShoppingCart.Order.Application.Features.CQRS.Results.AddressResults;
using ShoppingCart.Order.Application.Interfaces;
using ShoppingCart.Order.Domain.Entities;

namespace ShoppingCart.Order.Application.Features.CQRS.Handlers.AdressHandlers
{
    public class GetAddressQueryHandler
    {
        private readonly IRepository<Address> _repository;

        public GetAddressQueryHandler(IRepository<Address> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAddressQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAddressQueryResult
            {
                AddressId = x.AddressId,
                City = x.City,
                Detail = x.Detail,
                District = x.District,
                UserId = x.UserId,
            }).ToList();
        }
    }
}