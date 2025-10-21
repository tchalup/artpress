using FluentAssertions;
using Artpress.Domain.Entities;
using System;
using Xunit;

namespace Artpress.Domain.UnitTests.Entities
{
    public class UserTests
    {
        [Fact]
        public void User_SetProperties_ShouldHaveCorrectValues()
        {
            // Arrange
            var user = new User();
            var id = Guid.NewGuid();
            var name = "Test User";
            var email = "test@example.com";

            // Act
            user.Id = id;
            user.Name = name;
            user.Email = email;

            // Assert
            user.Id.Should().Be(id);
            user.Name.Should().Be(name);
            user.Email.Should().Be(email);
        }
    }
}
