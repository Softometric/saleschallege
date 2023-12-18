
using Application.Common.Extensions;
using Application.Common.Interfaces.Repository;
using Application.Common.Model;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.UseCases.InventoryManagement.Commands
{
    public class CreateInventoryCommand : IRequest<ResponseModel>
    {
        public string? ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal CostPrice { get; set; }
    }

    public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommand, ResponseModel>
    {
        private readonly IUnitOfWork _uow;

        public CreateInventoryCommandHandler(IUnitOfWork unitOfWork)
        {
            _uow = unitOfWork;
           
        }

        public async Task<ResponseModel> Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
        {
           
            _uow.InventoryStore.Insert(new Inventory
            {
                ProductId = request.ProductId.ConvertToGUID(),
                CostPrice = request.CostPrice,
                Quantity = request.Quantity,
                Created = DateTime.Now
            });
            await _uow.Commit();
            return ResponseModel.Success("You have successfully created new inventory");

        }
    }
}
