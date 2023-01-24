using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Topics.Queries.GetTopicsWithPagination;

public record GetTopicsWithPaginationQuery : IRequest<PaginatedList<TopicBriefDto>>
{
    public int Id { get; init; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;
}

public class GetTopicsWithPaginationQueryHandler : IRequestHandler<GetTopicsWithPaginationQuery, PaginatedList<TopicBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTopicsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<TopicBriefDto>> Handle(GetTopicsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.Topics
            .Where(x => x.SectionId == request.Id)
            .OrderBy(x => x.Created)
            .ProjectTo<TopicBriefDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
