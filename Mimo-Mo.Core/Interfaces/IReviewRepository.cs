using Mimo_Mo.Core.Entities;

namespace Mimo_Mo.Core.Interfaces;

public interface IReviewRepository
{
    Task<IEnumerable<Review>> GetAllReviewAsync();
    Task<Review?> GetReviewByIdAsync(int id); 
    Task<Review> CreateReviewAsync(Review review);
    Task<Review?>   UpdateReviewAsync(int id, Review review);
    Task<Review?>   DeleteReviewAsync(int id);
}