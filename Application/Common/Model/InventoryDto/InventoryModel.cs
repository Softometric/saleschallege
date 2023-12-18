namespace Application.Common.Models.InventoryDto
{
    public class InventoryModel
    {
        public string? Id { get; set; }
        public int Quantity { get; set; }
        public decimal? CostPrice { get; set; }
        public string? ProductId { get; set; }
    }
}
