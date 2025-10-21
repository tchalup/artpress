using FluentAssertions;
using FluentValidation.TestHelper;
using Artpress.Application.DTOs.Users;
using Artpress.Application.Validators.Users;
using Xunit;

namespace Artpress.Application.UnitTests.Validators
{
    public class CreateUserRequestValidatorTests
    {
        private readonly CreateUserRequestValidator _validator;

        public CreateUserRequestValidatorTests()
        {
            _validator = new CreateUserRequestValidator();
        }

        [Fact]
        public void Should_Have_Error_When_Name_Is_Null()
        {
            var model = new CreateUserRequest { Name = null };
            var result = _validator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);
        }

        [Fact]
        public void Should_Not_Have_Error_When_Name_Is_Specified()
        {
            var model = new CreateUserRequest { Name = "Test User" };
            var result = _validator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.Name);
        }
    }
}
