using FluentValidation;

namespace CleanArchitecture.Application.Sections.Queries.GetSectionsWithPagination;

public class GetSectionsQueryValidator : AbstractValidator<GetSections>
{
    public GetSectionsQueryValidator()
    {
    }
}
