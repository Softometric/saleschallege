using Application.Common.Extensions;
using Application.Common.Interfaces.Repository;
using Application.Common.Model;
using Application.UseCases.InventoryManagement.Commands;
using Domain.Entities;
using Domain.Enums;
using MediatR;

namespace Application.UseCases.SalesOrderManagement.Commands
{
    public class OrderNewProductCommand : IRequest<ResponseModel>
    {
        public string? ProductId { get; set; }
        public string? CustomerId { get; set; }
        public int Quantity { get; set; }
        public decimal CostPrice { get; set; }
    }

    public class OrderNewProductCommandHandler : IRequestHandler<OrderNewProductCommand, ResponseModel>
    {
        private readonly IUnitOfWork _uow;

        public OrderNewProductCommandHandler(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
           
        }

        public async Task<ResponseModel> Handle(OrderNewProductCommand request, CancellationToken cancellationToken)
        {
            var order = new SalesOrder
            {
                ProductId = request.ProductId!.ConvertToGUID(),
                UnitPrice = request.CostPrice,
                Quantity = request.Quantity,
                Created = DateTime.Now,
                SalesStatus = SalesStatus.Initiated,
                CustomerId = request.CustomerId!.ConvertToGUID()
            };
            
                _uow.SalesOrderStore.Insert(order);
                await _uow.Commit();
       

            return ResponseModel.Success("Your order has been successfully booked")!;

        }
    }
}
