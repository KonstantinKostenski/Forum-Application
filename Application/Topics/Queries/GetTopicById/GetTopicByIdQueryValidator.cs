using FluentValidation;

namespace CleanArchitecture.Application.Topics.Queries.GetTopicsWithPagination;

public class GetTopicByIdQueryValidator : AbstractValidator<GetTopicByIdQuery>
{
    public GetTopicByIdQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ListId is required.");
    }
}
