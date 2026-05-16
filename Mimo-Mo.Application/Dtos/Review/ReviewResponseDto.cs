namespace Mimo_Mo.Application.Dtos.Review;

public class ReviewResponseDto
{
    public int Id { get; set; }
    public string? Comment { get; set; }
    public string ReviewedBy { get; set; } 
    public int ProductId { get; set; }
    public DateTime Date { get; set; }
}