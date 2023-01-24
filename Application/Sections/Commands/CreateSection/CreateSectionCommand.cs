using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;
using MediatR;

namespace CleanArchitecture.Application.Sections.Commands.CreateSection;

public record CreateSectionCommand : IRequest<int>
{
    public int TopicId { get; init; }
    public string? Message { get; init; }
}

public class CreateSectionCommandHandler : IRequestHandler<CreateSectionCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateSectionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateSectionCommand request, CancellationToken cancellationToken)
    {
        var entity = new Reply
        {
            TopicId = request.TopicId,
            Message = request.Message
        };


        _context.Replies.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}
