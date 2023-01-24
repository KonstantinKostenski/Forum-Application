using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Topics.Commands.UpdateTopic;

public record UpdateTopicCommand : IRequest
{
    public int Id { get; set; }

    public int SectionId { get; init; }

    public string? Title { get; init; }

    public string? Description { get; init; }
}

public class UpdateTopicCommandHandler : IRequestHandler<UpdateTopicCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateTopicCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateTopicCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Topics
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Topic), request.Id);
        }

        entity.Title = request.Title;
        entity.Description = request.Description;
        entity.SectionId = request.SectionId;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
