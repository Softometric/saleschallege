
using Application.Common.Extensions;
using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Persistence.Factories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class InventoryRepository : Repository<Inventory>, IInventoryRepository
    {
        public InventoryRepository(SalesDbContext context) : base(context)
        {
        }

        public async Task<bool> ProductExists(string productId)
        {
            return await context.Products.AnyAsync(c => c.Id == productId.ConvertToGUID());
        }

    }
}
