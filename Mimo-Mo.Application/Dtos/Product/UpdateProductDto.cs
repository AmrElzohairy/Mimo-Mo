namespace Mimo_Mo.Application.Dtos.Product;

public record UpdateProductDto(int Id,string? Name, string? Description, decimal? Price, int? Quantity);