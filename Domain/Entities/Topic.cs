namespace CleanArchitecture.Domain.Entities;

public class Topic: BaseAuditableEntity
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public int SectionId { get; set; }
    public Section ? Section { get; set; }
}
