using FluentAssertions;
using MCB.Core.Infra.CrossCutting.Time;
using System;
using Xunit;

namespace MCB.Core.Infra.CrossCutting.Tests.TimeTests
{
    public class TimeProviderTest
    {
        [Fact]
        public void TimeProvider_Should_Return_GetUtcNow()
        {
            // Arrange
            var utcNow = DateTimeOffset.UtcNow;

            // Act
            var timeProviderUtcNow = TimeProvider.GetUtcNow();

            // Assert
            timeProviderUtcNow.Should().BeAfter(utcNow);
        }
        [Fact]
        public void TimeProvider_Should_Inject_UtcNow()
        {
            // Arrange
            var utcNow = DateTimeOffset.UtcNow;

            // Act
            TimeProvider.InjectedUtcNow = utcNow;
            var timeProviderUtcNow = TimeProvider.GetUtcNow();

            // Assert
            timeProviderUtcNow.Should().Be(utcNow);
        }
    }
}
