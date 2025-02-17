using MediatR;
using ShoppingCart.Order.Application.Features.CQRS.Queries.AddressQueries;
using ShoppingCart.Order.Application.Features.Mediator.Queries;
using ShoppingCart.Order.Application.Features.Mediator.Results;
using ShoppingCart.Order.Application.Interfaces;
using ShoppingCart.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.Order.Application.Features.Mediator.Handlers
{
    public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
    {
        private readonly IRepository<Ordering> _repository;

        public GetOrderingByIdQueryHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetOrderingByIdQueryResult
            {
                OrderDate = value.OrderDate,
                OrderingId = value.OrderingId,
                TotalPrice = value.TotalPrice,
                UserId = value.UserId
            };
        }
    }
}