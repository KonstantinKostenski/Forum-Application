namespace CleanArchitecture.Domain.Entities;

public class Section: BaseAuditableEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
}
