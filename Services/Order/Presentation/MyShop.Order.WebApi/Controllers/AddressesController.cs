using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Order.Application.Features.CQRS.Commands.AddressCommands;
using MyShop.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using MyShop.Order.Application.Features.CQRS.Queries.AddressQueries;

namespace MyShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressesController : ControllerBase
    {
        GetAddressQueryHandler _getAddressQueryHandler;
        GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
        CreateAddressCommandHandler _createAddressCommandHandler;
        UpdateAddressCommandHandler _updateAddressCommandHandler;
        RemoveAddressCommandHandler _removeAddressCommandHandler;

        public AddressesController(GetAddressQueryHandler getAddressQueryHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler, RemoveAddressCommandHandler removeAddressCommandHandler)
        {
            _getAddressQueryHandler = getAddressQueryHandler;
            _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
            _createAddressCommandHandler = createAddressCommandHandler;
            _updateAddressCommandHandler = updateAddressCommandHandler;
            _removeAddressCommandHandler = removeAddressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AddressList()
        {
            var values = await _getAddressQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressListById(int id)
        {
            var values = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAddress(CreateAddressCommand command)
        {
            await _createAddressCommandHandler.Handle(command);
            return Ok("Adres bilgisi başarıyla eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAddress(UpdateAddressCommand command)
        {
            await _updateAddressCommandHandler.Handle(command);
            return Ok("Adres Bilgisi başarıyla güncellendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveAddress(RemoveAddressCommand command)
        {
            await _removeAddressCommandHandler.Handle(command);
            return Ok("Adres Bilgisi başarıyla silindi");
        }
    }
}
