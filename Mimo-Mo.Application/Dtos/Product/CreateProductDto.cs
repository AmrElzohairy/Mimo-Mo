namespace Mimo_Mo.Application.Dtos.Product;

public record CreateProductDto(string Name, string Description, decimal Price, int Quantity,int UserId);