using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using ShoppingCart.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using ShoppingCart.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace ShoppingCart.Order.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler _removeProductDetailCommandHandler;
        private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;

        public OrderDetailsController(CreateOrderDetailCommandHandler createOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, RemoveOrderDetailCommandHandler removeProductDetailCommandHandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, GetOrderDetailQueryHandler getOrderDetailQueryHandler)
        {
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            _removeProductDetailCommandHandler = removeProductDetailCommandHandler;
            _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDetailList()
        {
            var values = await _getOrderDetailQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var value = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(value);
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveOrderDetail(RemoveOrderDetailCommand command)
        {
            await _removeProductDetailCommandHandler.Handle(command);
            return Ok("Sipariş Detayı Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailCommandHandler.Handle(command);
            return Ok("Sipariş Detayı Güncellendi");
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand command)
        {
            await _createOrderDetailCommandHandler.Handle(command);
            return Ok("Sipariş Detayı Oluşturuldu");
        }
    }
}