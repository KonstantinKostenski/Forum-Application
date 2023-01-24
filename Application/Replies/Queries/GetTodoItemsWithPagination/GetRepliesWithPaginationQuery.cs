using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Replies.Queries.GetRepliesWithPagination;

public record GetRepliesWithPaginationQuery : IRequest<PaginatedList<ReplyBiefDto>>
{
    public int ListId { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetRepliesWithPaginationQueryHandler : IRequestHandler<GetRepliesWithPaginationQuery, PaginatedList<ReplyBiefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetRepliesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<ReplyBiefDto>> Handle(GetRepliesWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Replies
            .Where(x => x.Id == request.ListId)
            .OrderBy(x => x.Message)
            .ProjectTo<ReplyBiefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
