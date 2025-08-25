using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Cargo.Business.Abstract;
using MyShop.Cargo.Dto.Dtos.CargoDetailDtos;
using MyShop.Cargo.Entity.Concrete;

namespace MyShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        ICargoDetailService _CargoDetailService;

        public CargoDetailsController(ICargoDetailService CargoDetailService)
        {
            _CargoDetailService = CargoDetailService;
        }

        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = _CargoDetailService.TGetAll();
            return Ok(values);
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
            _CargoDetailService.TInsert(cargoDetail);
            return Ok("Kargo Detayları Başarıyla Oluşturuldu.");
        }

        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _CargoDetailService.TDelete(id);
            return Ok("Kargo Detayları Başarıyla Silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var values = _CargoDetailService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto updateCargoDetailDto)
        {
            CargoDetail cargoDetail = new CargoDetail()
            {
                CargoDetailId = updateCargoDetailDto.CargoDetailId,
                Barcode = updateCargoDetailDto.Barcode,
                CargoCompanyId = updateCargoDetailDto.CargoCompanyId,
                ReceiverCustomer = updateCargoDetailDto.ReceiverCustomer,
                SenderCustomer = updateCargoDetailDto.SenderCustomer
            };
            _CargoDetailService.TUpdate(cargoDetail);
            return Ok("Kargo Şirketi Başarıyla Güncellendi.");
        }
    }
}
