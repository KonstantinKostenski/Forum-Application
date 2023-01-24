using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Topics.Queries.GetTopicsWithPagination;

public class TopicBriefDto : IMapFrom<Topic>
{
    public int Id { get; set; }

    public int SectionId { get; set; }

    public string? Title { get; set; }

    public string? Description { get; set; }

    public string? CreatedBy { get; set; }
}
