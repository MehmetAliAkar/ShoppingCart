using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Cargo.BusinessLayer.Abstract;
using ShoppingCart.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using ShoppingCart.Cargo.EntityLayer.Concrete;

namespace ShoppingCart.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _cargoOperationService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult CargoOperation(int id)
        {
            var value = _cargoOperationService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationTime = createCargoOperationDto.OperationTime
            };
            _cargoOperationService.TInsert(cargoOperation);
            return Ok("Kargo İşlemleri Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo İşlemleri Silindi");
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                OperationTime = updateCargoOperationDto.OperationTime,
                Description = updateCargoOperationDto.Description,
                CargoOperationId = updateCargoOperationDto.CargoOperationId,
                Barcode = updateCargoOperationDto.Barcode
            };
            _cargoOperationService.TUpdate(cargoOperation);
            return Ok("Kargo İşlemleri Başarıyla Güncellendi");
        }
    }
}
