namespace Mimo_Mo.Application.Dtos.Review;

public record CreateReviewDto(string? Comment, int ProductId, int UserId);
