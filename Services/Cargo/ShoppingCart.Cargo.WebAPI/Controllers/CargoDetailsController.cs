using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingCart.Cargo.BusinessLayer.Abstract;
using ShoppingCart.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using ShoppingCart.Cargo.EntityLayer.Concrete;

namespace ShoppingCart.Cargo.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            _cargoDetailService = cargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _cargoDetailService.TGetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult CargoDetail(int id)
        {
            var value = _cargoDetailService.TGetById(id);
            return Ok(value);
        }

        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto createCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                Barcode = createCargoDetailDto.Barcode,
                CargoCompanyId = createCargoDetailDto.CargoCompanyId,
                ReceiverCustomer = createCargoDetailDto.ReceiverCustomer,
                SenderCustomer = createCargoDetailDto.SenderCustomer
            };
            _cargoDetailService.TInsert(cargoDetail);
            return Ok("Kargo Detayları Eklendi");
        }

        [HttpDelete]
        public IActionResult DeleteCargoDetail(int id)
        {
            _cargoDetailService.TDelete(id);
            return Ok("Kargo Detayları Silindi");
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                Barcode =updateCargoDetailDto.Barcode,
                SenderCustomer = updateCargoDetailDto.ReceiverCustomer,
                ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
                CargoDetailId = updateCargoDetailDto.CargoDetailId,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId
            };
            _cargoDetailService.TUpdate(cargoDetail);
            return Ok("Kargo Detayları Başarıyla Güncellendi");
        }
    }
}
