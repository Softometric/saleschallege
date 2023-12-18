using Application.Common.Extensions;
using Application.Common.Interfaces.Repository;
using Application.Common.Model;
using Application.Common.Model.SalesOrderDto;
using Application.Common.Models.InventoryDto;
using Application.UseCases.InventoryManagement.Queries;
using Azure;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.UseCases.SalesOrderManagement.Queries
{
    public class GetCustomerOrdersQuery : IRequest<ResponseModel>
    {
        public string CustomerId { get; set; }
    }
    public class GetCustomerOrdersQueryHandler : IRequestHandler<GetCustomerOrdersQuery, ResponseModel>
    {
        private readonly IUnitOfWork _uow;

        public GetCustomerOrdersQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
           
        }
        public async Task<ResponseModel> Handle(GetCustomerOrdersQuery request, CancellationToken cancellationToken)
        {
            if (_uow.CustomerStore.GetByID(request.CustomerId.ConvertToGUID()) is not { } customer)
            {
                return ResponseModel.Failure("Unable to retrieve customer's detail");
            }

            var shipping = new ShippingDetail
            {
                CustomerId = customer.Id.ToString(),
                Country = customer.CustomerAddress!.Country,
                Street = customer.CustomerAddress!.Street,
                FullName = $"{customer.FirstName} {customer.OtherName} {customer.LastName}",
                PhoneNumber = customer.PhoneNo,
                ZipCode = customer.CustomerAddress.ZipCode
            };
            if (_uow.SalesOrderStore.Get(c=>c.CustomerId.Equals(customer.Id)) is not { } orders)
            {
                return ResponseModel<DashBoardOrderModel>.Success(data: new DashBoardOrderModel
                {
                    Shipping = shipping,
                    OrderModels = new List<OrderModel>()
                }, "Order list is empty");
            }

            return ResponseModel<DashBoardOrderModel>.Success(data: new DashBoardOrderModel
            {
                Shipping = shipping,
                OrderModels = orders.Select(c => new OrderModel
                {
                    Product = _uow.ProductStore.GetByID(c.ProductId!)?.Name,
                    Quantity = c.Quantity,
                    Status = c.SalesStatus!.GetDescription(),
                    OrderDate = c.Created,
                    TotalAmount = c.Quantity * c.UnitPrice,
                    UnitPrice = c.UnitPrice,
                    OrderId = c.Id.ToString()
                }).ToList()
            });
        }
    }
}
