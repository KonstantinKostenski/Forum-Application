using FluentValidation;

namespace CleanArchitecture.Application.Replies.Queries.GetRepliesWithPagination;

public class GetRepliesByTopicWithPaginationQueryValidator : AbstractValidator<GetRepliesByTopicWithPaginationQuery>
{
    public GetRepliesByTopicWithPaginationQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Topic Id is required.");

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
