using CleanArchitecture.Application.Common.Mappings;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Replies.Queries.GetRepliesWithPagination;

public class ReplyBiefDto : IMapFrom<Reply>
{
    public int Id { get; set; }
    public int TopicId { get; set; }
    public string? Message { get; set; }
    public string? CreatedBy { get; set; }
}
