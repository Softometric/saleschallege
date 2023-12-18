using Application.Common.Model;
using Application.Common.Models;
using Application.Common.Models.InventoryDto;
using Application.Common.Models.ProductDto;
using Application.UseCases.InventoryManagement.Commands;
using Application.UseCases.InventoryManagement.Queries;
using Microsoft.AspNetCore.Mvc;


namespace Presentation.Controllers
{
    public class InventoryController : ApiControllerBase
    {
        [HttpPost]
        [Route("CreateInventory")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateInventoryCommand command)
        {
            var result = await Mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : (IActionResult)BadRequest(result);
        }
        [HttpGet]
        [Route("GetInventories")]
        [ProducesResponseType(typeof(ResponseModel<InventoryModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProducts()
        {
            var result = await Mediator.Send(new GetInventoriesQuery{});
            return result.IsSuccessful ? Ok(result) : (IActionResult)BadRequest(result);
        }

        [HttpDelete]
        [Route("delete-inventory/{inventoryId}")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteInventory([FromRoute] string inventoryId)
        {
            var command = new DeleteInventoryCommand
            {
                InventoryId = inventoryId
            };

            var result = await Mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : (IActionResult)BadRequest(result);
        }
    }
}
