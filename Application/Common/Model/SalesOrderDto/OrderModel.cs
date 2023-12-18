using System.Reflection.Metadata.Ecma335;

namespace Application.Common.Model.SalesOrderDto;

public class OrderModel
{
    public string? OrderId { get; set; }
    public DateTime OrderDate { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal TotalAmount { get; set; }
    public string? Status { get; set; }
    public string? Product { get; set; }
}

public class ShippingDetail
{
    public string? CustomerId { get; set; }
    public string? FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? EmailAddress { get; set; }
    public string? Country { get; set; }
    public string? Street { get; set; }
    public string? ZipCode { get; set; }
}

public class DashBoardOrderModel
{
    public ShippingDetail Shipping { get; set; }
    public List<OrderModel> OrderModels { get; set; }
}