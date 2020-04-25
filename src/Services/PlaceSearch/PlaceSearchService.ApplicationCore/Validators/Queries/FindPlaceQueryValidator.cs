using FluentValidation;
using PlaceSearchService.Api.Queries;

namespace PlaceSearchService.ApplicationCore.Validators.Queries
{
    public class FindPlaceQueryValidator : AbstractValidator<FindPlaceQuery>
    {
        public FindPlaceQueryValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}
