using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Replies.Commands.UpdateReply;

public record UpdateReplyCommand : IRequest
{
    public int Id { get; set; }
    public string? Message { get; init; }
}

public class UpdateReplyCommandHandler : IRequestHandler<UpdateReplyCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateReplyCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateReplyCommand request, CancellationToken cancellationToken)
    {
        var entity = await _context.Replies
            .FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(Reply), request.Id);
        }

        entity.Message = request.Message;

        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}
