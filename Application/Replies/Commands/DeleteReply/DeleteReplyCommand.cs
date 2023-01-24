using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Events;
using MediatR;

namespace CleanArchitecture.Application.Replies.Commands.DeleteReply;

public record DeleteReplyCommand(int Id) : IRequest;

public class DeleteReplyCommandHandler : IRequestHandler<DeleteReplyCommand>
{
    private readonly IApplicationDbContext _context;

    public DeleteReplyCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteReplyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Replies
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(TodoItem), request.Id);
        }

        _context.Replies.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
