namespace CleanArchitecture.Domain.Entities;

public class Reply: BaseAuditableEntity
{
    public string? Message { get; set; }
    public int TopicId { get; set; }
    public Topic? Topic { get; set; }
}
