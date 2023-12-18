
using Application.Common.Interfaces.Repository;
using Application.Common.Model;
using Application.Common.Models;
using Domain.Entities;
using MediatR;
using Microsoft.Extensions.Configuration;

namespace Application.UseCases.ProductManagement.Commands
{
    public class CreateProductCommand : IRequest<ResponseModel>
    {
       
        public string ProductName { get; set; }
    }

    public class CreateCommandHandler : IRequestHandler<CreateProductCommand, ResponseModel>
    {
        private readonly IUnitOfWork _uow;
        private readonly IConfiguration _configuration;


        public CreateCommandHandler(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _uow = unitOfWork;
            _configuration = configuration;
           
        }

        public async Task<ResponseModel> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            if (await _uow.ProductStore.ProductExists(request.ProductName))
                return ResponseModel.Failure("Product with similar name already created");
            _uow.ProductStore.Insert(new Product
            {
                Name = request.ProductName,
            });
            await _uow.Commit();
            return ResponseModel.Success("You have successfully created new product");

        }
    }
}
