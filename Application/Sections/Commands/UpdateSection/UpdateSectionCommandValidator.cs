using FluentValidation;

namespace CleanArchitecture.Application.Sections.Commands.UpdateSection;

public class UpdateSectionCommandValidator : AbstractValidator<UpdateSectionCommand>
{
    public UpdateSectionCommandValidator()
    {
        RuleFor(v => v.Message)
            .MaximumLength(1000)
            .NotEmpty();
    }
}
