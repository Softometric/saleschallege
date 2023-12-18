
using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Persistence.Factories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(SalesDbContext context) : base(context)
        {
        }

        public async Task<bool> ProductExists(string name)
        {
            name = name.ToLower();
            return await context.Products.AnyAsync(c => c.Name.ToLower() == name);
        }

    }
}
