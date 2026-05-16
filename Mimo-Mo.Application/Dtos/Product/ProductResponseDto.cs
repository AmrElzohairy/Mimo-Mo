namespace Mimo_Mo.Application.Dtos.Product;

public class ProductResponseDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string? Image { get; set; }
    public decimal Price { get; set; }
    public decimal? Discount { get; set; }
    public bool IsAvailable { get; set; }
    public int Quantity { get; set; }
    public string AddedBy { get; set; }
    public DateTime CreatedAt { get; set; }
}