using FluentValidation.TestHelper;
using PlaceSearchService.Api.Queries;
using PlaceSearchService.ApplicationCore.Validators.Queries;
using Xunit;

namespace PlaceSearchService.UnitTests.Validators
{
    public class FindPlaceQueryValidatorTests
    {
        private readonly FindPlaceQueryValidator validator = new FindPlaceQueryValidator();

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        public void Validate_WhenNameIsEmpty_ShouldHaveValidationError(string name)
        {
            var result = validator.TestValidate(new FindPlaceQuery
            {
                Name = name
            });

            result.ShouldHaveValidationErrorFor(x => x.Name)
                .WithErrorCode(ValidationErrorCodes.NotEmptyValidator);
        }

        [Fact]
        public void Validate_WhenNameIsFilled_ShouldNotHaveValidationError()
        {
            var result = validator.TestValidate(new FindPlaceQuery
            {
                Name = "test"
            });

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
