using AutoMapper;
using MediatR;
using Mimo_Mo.Application.Common.Responses;
using Mimo_Mo.Application.Dtos.Review;
using Mimo_Mo.Core.Interfaces;

namespace Mimo_Mo.Application.Features.Reviews.Queries.GetAllReviews;

public class GetAllReviewsQueryHandler : IRequestHandler<GetAllReviewsQuery,ApiResponse<IEnumerable<ReviewResponseDto>>>
{
    private readonly IMapper _mapper;
    private  readonly IReviewRepository _reviewRepository;

    public GetAllReviewsQueryHandler(IMapper mapper, IReviewRepository reviewRepository)
    {
        _mapper = mapper;
        _reviewRepository = reviewRepository;
    }
    
    public async Task<ApiResponse<IEnumerable<ReviewResponseDto>>> Handle(GetAllReviewsQuery request, CancellationToken cancellationToken)
    {
        var reviews = await _reviewRepository.GetAllReviewAsync();
        var reviewDtos = _mapper.Map<IEnumerable<ReviewResponseDto>>(reviews);
        return new ApiResponse<IEnumerable<ReviewResponseDto>>(reviewDtos);
    }
}