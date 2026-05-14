namespace Mimo_Mo.Application.Dtos.Product;

public class ProductDto
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public decimal Price { get; set; }
    
    public decimal? DiscountPrice { get; set; }
    
    public string? Image { get; set; }
    
    public int Quantity { get; set; }
    
    public bool IsAvailable { get; set; }
    
    public DateTime CreatedAt { get; set; }
}