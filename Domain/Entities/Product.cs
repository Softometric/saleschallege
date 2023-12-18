using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class Product: BaseEntity
{
    public Product()
    {
        this.Inventories = new HashSet<Inventory>();
        this.SalesOrders = new HashSet<SalesOrder>();
;    }
    public string? Name { get; set; }
    public ICollection<Inventory>? Inventories { get; set; }
    public ICollection<SalesOrder>? SalesOrders { get; set; }
}