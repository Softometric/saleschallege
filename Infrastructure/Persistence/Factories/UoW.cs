using Application.Common.Interfaces.Repository;

namespace Infrastructure.Persistence.Factories
{
    public class UoW : IUnitOfWork
    {
        private readonly SalesDbContext _context;
        public UoW(SalesDbContext context, IProductRepository productStore, IInventoryRepository inventoryStore, 
                  ICustomerRepository customerStore, ISalesOrderRepository salesOrderStore)
        {
            _context = context;
            ProductStore = productStore;
            InventoryStore = inventoryStore;
            CustomerStore = customerStore;
            SalesOrderStore = salesOrderStore;
        }

        private bool _disposed;
        
        public IProductRepository ProductStore { get; }

        public IInventoryRepository InventoryStore { get; }

        public ICustomerRepository CustomerStore { get; }
        public ISalesOrderRepository SalesOrderStore { get; }

        public async Task Commit()
        {
            try
            {
                var row = await _context.SaveChangesAsync(CancellationToken.None);
            }
            catch (Exception ex)
            {
                var m = ex.Message;
            }
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            _disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
