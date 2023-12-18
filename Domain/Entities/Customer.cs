using Domain.Common;
using Domain.Enums;
using Domain.ValueObject;

namespace Domain.Entities;

public class Customer :BaseEntity
{
    public Customer()
    {
        this.SalesOrders =new HashSet<SalesOrder>();
    }

    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public string? OtherName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNo { get; set; }
    public Sex Gender  { get; set; }
    public  Address? CustomerAddress  { get;  set; }
    public  ICollection<SalesOrder> SalesOrders  { get; private set; }
}