using FluentValidation;

namespace CleanArchitecture.Application.Topics.Queries.GetTopicsWithPagination;

public class GetTopicsWithPaginationQueryValidator : AbstractValidator<GetTopicsWithPaginationQuery>
{
    public GetTopicsWithPaginationQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("ListId is required.");

        RuleFor(x => x.PageNumber)
            .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        RuleFor(x => x.PageSize)
            .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
