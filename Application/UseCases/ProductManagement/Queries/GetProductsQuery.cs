using System.Text.Json.Serialization;
using Application.Common.Interfaces.Repository;
using Application.Common.Model;
using Application.Common.Models;
using Application.Common.Models.ProductDto;
using MediatR;

namespace Application.UseCases.ProductManagement.Queries
{
    public class GetProductsQuery : IRequest<ResponseModel>
    {
        [JsonIgnore]
        public string? ApplicationRef { get; set; }
    }
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, ResponseModel>
    {
        private readonly IUnitOfWork _uow;

        public GetProductsQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
           
        }
        public async Task<ResponseModel> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            if ( _uow.ProductStore.Get() is not { } products)
            {
                return ResponseModel<List<ProductModel>>.Success(data:new List<ProductModel>(),"Product list is empty");
            }
           
            return ResponseModel<List<ProductModel>>.Success(data: products.Select(c=>new ProductModel
            {
                Id = c.Id.ToString(),
               ProductName  = c.Name
            }).ToList());
        }
    }
}
