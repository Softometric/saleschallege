using Application.Common.Extensions;
using Application.Common.Model;
using Application.Common.Model.SalesOrderDto;
using Application.Common.Models;
using Application.Common.Models.ProductDto;
using Application.UseCases.CustomerManagement.Queries;
using Application.UseCases.ProductManagement.Commands;
using Application.UseCases.ProductManagement.Queries;
using Application.UseCases.SalesOrderManagement.Commands;
using Application.UseCases.SalesOrderManagement.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Presentation.Controllers
{
    public class DashBoardController : ApiControllerBase
    {
        [HttpPost]
        [Route("CreateOrder")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] OrderNewProductCommand command)
        {
            var result = await Mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : (IActionResult)BadRequest(result);
        }
        [HttpGet]
        [Route("GetCustomerOrder/{customerId}")]
        [ProducesResponseType(typeof(ResponseModel<DashBoardOrderModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetCustomerOrder([FromRoute]string customerId)
        {
            var result = await Mediator.Send(new GetCustomerOrdersQuery{CustomerId = customerId});
            return result.IsSuccessful ? Ok(result) : (IActionResult)BadRequest(result);
        }

       
    }
}
