using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Sections.Queries.GetSectionsWithPagination;

public class SectionBriefDto : IMapFrom<Section>
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }
}
