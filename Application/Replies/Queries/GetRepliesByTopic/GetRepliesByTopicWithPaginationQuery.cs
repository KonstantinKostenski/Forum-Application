using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using MediatR;

namespace CleanArchitecture.Application.Replies.Queries.GetRepliesWithPagination;

public record GetRepliesByTopicWithPaginationQuery : IRequest<PaginatedList<ReplyBiefDto>>
{
    public int Id { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetRepliesByTopicWithPaginationQueryHandler : IRequestHandler<GetRepliesByTopicWithPaginationQuery, PaginatedList<ReplyBiefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRepliesByTopicWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ReplyBiefDto>> Handle(GetRepliesByTopicWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Replies
            .Where(x => x.TopicId == request.Id)
            .OrderBy(x => x.Message)
            .ProjectTo<ReplyBiefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
