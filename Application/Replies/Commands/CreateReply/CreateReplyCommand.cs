using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;
using MediatR;

namespace CleanArchitecture.Application.Replies.Commands.CreateReply;

public record CreateReplyCommand : IRequest<int>
{
    public int TopicId { get; init; }
    public string? Message { get; init; }
}

public class CreateReplyCommandHandler : IRequestHandler<CreateReplyCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateReplyCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateReplyCommand request, CancellationToken cancellationToken)
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
