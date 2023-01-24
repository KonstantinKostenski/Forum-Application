using FluentValidation;

namespace CleanArchitecture.Application.Sections.Commands.CreateSection;

public class CreateSectionCommandValidator : AbstractValidator<CreateSectionCommand>
{
    public CreateSectionCommandValidator()
    {
        RuleFor(v => v.Message)
            .MaximumLength(1000)
            .NotEmpty();

        RuleFor(v => v.TopicId)
            .NotEmpty();
    }
}
