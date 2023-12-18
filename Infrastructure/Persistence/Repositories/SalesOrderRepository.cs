
using Application.Common.Interfaces.Repository;
using Domain.Entities;
using Infrastructure.Persistence.Factories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repositories
{
    public class SalesOrderRepository : Repository<SalesOrder>, ISalesOrderRepository
    {
        public SalesOrderRepository(SalesDbContext context) : base(context)
        {
        }
        

    }
}
