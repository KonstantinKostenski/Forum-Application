using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;
using MediatR;

namespace CleanArchitecture.Application.Topics.Commands.CreateTopic;

public record CreateTopicCommand : IRequest<int>
{
    public int SectionId { get; init; }

    public string? Title { get; init; }

    public string? Description { get; init; }
}

public class CreateTopicCommandHandler : IRequestHandler<CreateTopicCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateTopicCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateTopicCommand request, CancellationToken cancellationToken)
    {
        var entity = new Topic
        {
            Title = request.Title,
            SectionId = request.SectionId,
            Description = request.Description
        };

        _context.Topics.Add(entity);
        try
        {
            await _context.SaveChangesAsync(cancellationToken);
        }
        catch (Exception ex)
        {

            throw;
        }
        

        return entity.Id;
    }
}
