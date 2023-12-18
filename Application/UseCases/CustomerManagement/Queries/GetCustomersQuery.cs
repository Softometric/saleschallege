using System.Text.Json.Serialization;
using Application.Common.Interfaces.Repository;
using Application.Common.Model;
using Application.Common.Models;
using Application.Common.Models.CustomerDto;
using Application.Common.Models.InventoryDto;
using Application.Common.Models.ProductDto;
using MediatR;

namespace Application.UseCases.CustomerManagement.Queries
{
    public class GetCustomersQuery : IRequest<ResponseModel>
    {
    }
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, ResponseModel>
    {
        private readonly IUnitOfWork _uow;

        public GetCustomersQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
           
        }
        public async Task<ResponseModel> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
        {
            if (_uow.CustomerStore.Get() is not { } customers)
            {
                return ResponseModel<List<CustomerModel>>.Success(data: new List<CustomerModel>(), "Customer list is empty");
            }

            return ResponseModel<List<CustomerModel>>.Success(data: customers.Select(c => new CustomerModel
            {
                Id = c.Id.ToString(),
               Email = c.Email,
               FirstName = c.FirstName,
               LastName = c.LastName,
               PhoneNo = c.PhoneNo
            }).ToList());
        }
    }
}
