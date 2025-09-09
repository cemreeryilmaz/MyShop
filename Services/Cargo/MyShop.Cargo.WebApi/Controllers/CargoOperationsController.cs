using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Cargo.Business.Abstract;
using MyShop.Cargo.Dto.Dtos.CargoOperationDtos;
using MyShop.Cargo.Entity.Concrete;

namespace MyShop.Cargo.WebApi.Controllers
{
    [Authorize]

    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        ICargoOperationService _cargoOperationService;

        public CargoOperationsController(ICargoOperationService CargoOperationService)
        {
            _cargoOperationService = CargoOperationService;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _cargoOperationService.TGetAll();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                Barcode = createCargoOperationDto.Barcode,
                Description = createCargoOperationDto.Description,
                OperationDate = createCargoOperationDto.OperationDate,
            };
            _cargoOperationService.TInsert(cargoOperation);
            return Ok("Kargo İşlemi Başarıyla Oluşturuldu.");
        }

        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);
            return Ok("Kargo İşlemi Başarıyla Silindi.");
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var values = _cargoOperationService.TGetById(id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            CargoOperation cargoOperation = new CargoOperation()
            {
                Barcode = updateCargoOperationDto.Barcode,
                Description = updateCargoOperationDto.Description,
                OperationDate = updateCargoOperationDto.OperationDate,
                CargoOperationId = updateCargoOperationDto.CargoOperationId,
            };
            _cargoOperationService.TUpdate(cargoOperation);
            return Ok("Kargo İşlemi Başarıyla Güncellendi.");
        }
    }
}
