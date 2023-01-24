using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Topics.Queries.GetTopicsWithPagination;

public record GetTopicByIdQuery : IRequest<Topic>
{
    public int Id { get; init; }
}

public class GetTopicByIdQueryQueryHandler : IRequestHandler<GetTopicByIdQuery, Topic>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetTopicByIdQueryQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Topic> Handle(GetTopicByIdQuery request, CancellationToken cancellationToken) => await _context.Topics
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
}
