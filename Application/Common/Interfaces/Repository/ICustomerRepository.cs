using Domain.Entities;

namespace Application.Common.Interfaces.Repository
{
    public interface ICustomerRepository : IRepository<Customer>
    {
        Task<bool> EmailExists(string email);
    }
}