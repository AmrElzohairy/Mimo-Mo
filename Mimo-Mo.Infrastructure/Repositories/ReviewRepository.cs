using Microsoft.EntityFrameworkCore;
using Mimo_Mo.Core.Entities;
using Mimo_Mo.Core.Interfaces;
using Mimo_Mo.Infrastructure.Data;

namespace Mimo_Mo.Infrastructure.Repositories;

public class ReviewRepository : IReviewRepository
{
    private readonly AppDbContext _Context;
    
    public ReviewRepository(AppDbContext context)
    {
        _Context = context;
    }
    
    public async Task<IEnumerable<Review>> GetAllReviewAsync()
    {
        return await _Context.Reviews.AsNoTracking()
            .Include(r => r.Product)
            .Include(r => r.User)
            .ToListAsync();
    }

    public async Task<Review?> GetReviewByIdAsync(int id)
    {
       return await  _Context.Reviews.AsNoTracking()
           .Include(r => r.Product)
           .Include(r => r.User)
           .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<Review> CreateReviewAsync(Review review)
    {
        var userReview = await _Context.AddAsync(review);
        await _Context.SaveChangesAsync();
        return  userReview.Entity;
    }

    public async Task<Review?> UpdateReviewAsync(int id, Review review)
    {
       var userReview = await _Context.Reviews.FirstOrDefaultAsync(r => r.Id == id);
       if (userReview == null) return null;
        _Context.Entry(userReview).CurrentValues.SetValues(review);
         await _Context.SaveChangesAsync();
        return userReview;
    }

    public async Task<Review?> DeleteReviewAsync(int id)
    {
        var review = await _Context.Reviews.FindAsync(id);
        if(review == null) return null;
        _Context.Reviews.Remove(review);
        await _Context.SaveChangesAsync();
        return review;
    }
}