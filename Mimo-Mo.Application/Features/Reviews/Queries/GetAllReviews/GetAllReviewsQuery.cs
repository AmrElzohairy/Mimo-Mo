using MediatR;
using Mimo_Mo.Application.Common.Responses;
using Mimo_Mo.Application.Dtos.Review;

namespace Mimo_Mo.Application.Features.Reviews.Queries.GetAllReviews;

public record GetAllReviewsQuery : IRequest<ApiResponse<IEnumerable<ReviewResponseDto>>>;
