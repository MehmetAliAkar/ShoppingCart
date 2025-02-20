using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Order.Application.Features.CQRS.Commands.AddressCommands;
using ShoppingCart.Order.Application.Features.CQRS.Handlers.AdressHandlers;
using ShoppingCart.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace ShoppingCart.Order.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        private readonly GetAddressQueryHandler _getAddressQueryHandler;
        private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        private readonly CreateAddressCommandHandler _createAddressCommandHandler;
        private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
        private readonly RemoveAddressCommandHandler _removeAddressCommandHandler;

        public AddressesController(GetAddressQueryHandler getAddressQueryHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, RemoveAddressCommandHandler removeAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler)
        {
            _getAddressQueryHandler = getAddressQueryHandler;
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _removeAddressCommandHandler = removeAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values = await _getAddressQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var value = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _createAddressCommandHandler.Handle(command);
            return Ok("Adres Bilgisi Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UdpateAddress(UpdateAddressCommand command)
        {
            await _updateAddressCommandHandler.Handle(command);
            return Ok("Adres Bilgisi Güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAddress(int id)
        {
            await _removeAddressCommandHandler.Handle(new RemoveAddressCommand(id));
            return Ok("Adres Bilgisi Silindi");
        }
    }
}