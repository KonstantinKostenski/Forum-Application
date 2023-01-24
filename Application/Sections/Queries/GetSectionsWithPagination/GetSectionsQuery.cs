using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Sections.Queries.GetSectionsWithPagination;

public record GetSections : IRequest<List<SectionBriefDto>>
{
}

public class GetSectionsQueryHandler : IRequestHandler<GetSections, List<SectionBriefDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetSectionsQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<SectionBriefDto>> Handle(GetSections request, CancellationToken cancellationToken)
    {
        return await _context.Sections
            .OrderBy(x => x.Name)
            .ProjectTo<SectionBriefDto>(_mapper.ConfigurationProvider)
            .ToListAsync();
    }
}
