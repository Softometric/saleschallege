using System.Text.Json.Serialization;
using Application.Common.Interfaces.Repository;
using Application.Common.Model;
using Application.Common.Models;
using Application.Common.Models.InventoryDto;
using Application.Common.Models.ProductDto;
using MediatR;

namespace Application.UseCases.InventoryManagement.Queries
{
    public class GetInventoriesQuery : IRequest<ResponseModel>
    {
    }
    public class GetProductsQueryHandler : IRequestHandler<GetInventoriesQuery, ResponseModel>
    {
        private readonly IUnitOfWork _uow;

        public GetProductsQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
           
        }
        public async Task<ResponseModel> Handle(GetInventoriesQuery request, CancellationToken cancellationToken)
        {
            if (_uow.InventoryStore.Get() is not { } inventories)
            {
                return ResponseModel<List<InventoryModel>>.Success(data: new List<InventoryModel>(), "Inventory list is empty");
            }

            return ResponseModel<List<InventoryModel>>.Success(data: inventories.Select(c => new InventoryModel
            {
                Id = c.Id.ToString(),
                CostPrice = c.CostPrice,
                Quantity = c.Quantity??0,
                ProductId = c.ProductId.ToString()
            }).ToList());
        }
    }
}
