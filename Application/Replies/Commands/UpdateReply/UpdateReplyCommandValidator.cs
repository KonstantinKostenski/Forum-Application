using FluentValidation;

namespace CleanArchitecture.Application.Replies.Commands.UpdateReply;

public class UpdateReplyCommandValidator : AbstractValidator<UpdateReplyCommand>
{
    public UpdateReplyCommandValidator()
    {
        RuleFor(v => v.Message)
            .MaximumLength(1000)
            .NotEmpty();
    }
}
