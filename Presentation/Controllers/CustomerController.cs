using Application.Common.Extensions;
using Application.Common.Model;
using Application.Common.Models;
using Application.Common.Models.CustomerDto;
using Application.Common.Models.ProductDto;
using Application.UseCases.CustomerManagement.Commands;
using Application.UseCases.CustomerManagement.Queries;
using Application.UseCases.ProductManagement.Commands;
using Application.UseCases.ProductManagement.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Presentation.Controllers
{
    public class CustomerController : ApiControllerBase
    {
        [HttpPost]
        [Route("CreateCustomer")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateCustomerCommand command)
        {
            var result = await Mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : (IActionResult)BadRequest(result);
        }
        [HttpGet]
        [Route("GetCustomers")]
        [ProducesResponseType(typeof(ResponseModel<CustomerModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetProducts()
        {
            var result = await Mediator.Send(new GetCustomersQuery{});
            return result.IsSuccessful ? Ok(result) : (IActionResult)BadRequest(result);
        }

        [HttpDelete]
        [Route("delete-customer/{customerId}")]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseModel), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteProduct([FromRoute] string customerId)
        {
            var command = new DeleteCustomerCommand
            {
                CustomerId = customerId
            };
            var result = await Mediator.Send(command);
            return result.IsSuccessful ? Ok(result) : (IActionResult)BadRequest(result);
        }
    }
}
