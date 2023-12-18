
using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Persistence.Factories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(SalesDbContext context) : base(context)
        {
        }

        public async Task<bool> EmailExists(string email)
        {
            email = email.ToLower();
            return await context.Customers.AnyAsync(c => c.Email!.ToLower() == email);
        }

    }
}
