namespace Mimo_Mo.Application.Dtos.Product;

public record ProductResponseDto(int Id, string Name, string Description, decimal Price,decimal Quantity ,bool IsAvailable);