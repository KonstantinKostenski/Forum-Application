using FluentValidation;

namespace CleanArchitecture.Application.Replies.Commands.CreateReply;

public class CreateReplyCommandValidator : AbstractValidator<CreateReplyCommand>
{
    public CreateReplyCommandValidator()
    {
        RuleFor(v => v.Message)
            .MaximumLength(1000)
            .NotEmpty();

        RuleFor(v => v.TopicId)
            .NotEmpty();
    }
}
