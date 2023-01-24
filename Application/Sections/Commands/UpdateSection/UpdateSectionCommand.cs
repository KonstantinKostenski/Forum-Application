using CleanArchitecture.Application.Common.Exceptions;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using MediatR;

namespace CleanArchitecture.Application.Sections.Commands.UpdateSection;

public record UpdateSectionCommand : IRequest
{
    public int Id { get; set; }
    public string? Message { get; init; }
}

public class UpdateSectionCommandHandler : IRequestHandler<UpdateSectionCommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateSectionCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(UpdateSectionCommand request, CancellationToken cancellationToken)
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
