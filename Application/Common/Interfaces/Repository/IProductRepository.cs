using Domain.Entities;

namespace Application.Common.Interfaces.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<bool> ProductExists(string name);
    }
}