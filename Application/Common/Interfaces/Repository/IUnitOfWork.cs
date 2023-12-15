
using Application.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductStore { get; }
        Task Commit();
    }
}
