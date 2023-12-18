using Domain.Common;
using Domain.Enums;

namespace Domain.Entities;

public class SalesOrder :BaseEntity
{
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public Guid CustomerId { get; set; }
    public Customer? Customer { get; set; }
    public Guid? ProductId { get; set; }
    public Product? Product { get; set; }
    public SalesStatus? SalesStatus { get; set; }
}