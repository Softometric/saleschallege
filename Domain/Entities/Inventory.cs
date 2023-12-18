using Domain.Common;

namespace Domain.Entities;

public class Inventory :BaseEntity
{
    public Guid ProductId { get; set; }
    public Product? Product { get; set; }
    public decimal? CostPrice { get; set; }
    public int? Quantity { get; set; }
}