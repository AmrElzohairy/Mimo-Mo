namespace Mimo_Mo.Core.Entities;

public class Product
{
    public int Id { get; set; }
    
    public string Name { get; set; }  = string.Empty;
    
    public string Description { get; set; } = string.Empty;
    
    public string? Image { get; set; }
    
    public decimal Price { get; set; }
    
    public decimal?  Discount { get; set; }
    
    public bool IsAvailable { get; set; }
    
    public int Quantity { get; set; }
    
    public int UserId { get; set; }
    
    public User User { get; set; }
    
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public DateTime UpdatedAt { get; set; } 
}