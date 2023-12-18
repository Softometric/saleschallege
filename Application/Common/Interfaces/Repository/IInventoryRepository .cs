using Domain.Entities;

namespace Application.Common.Interfaces.Repository
{
    public interface IInventoryRepository : IRepository<Inventory>
    {
        Task<bool> ProductExists(string productId);
    }
}