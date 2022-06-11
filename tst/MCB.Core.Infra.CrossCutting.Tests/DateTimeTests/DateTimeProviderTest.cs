using FluentAssertions;
using MCB.Core.Infra.CrossCutting.DateTime;
using System;
using Xunit;

namespace MCB.Core.Infra.CrossCutting.Tests.DateTimeTests;

public class DateTimeProviderTest
{
    [Fact]
    public void DateTimeProvider_Should_Return_GetDate()
    {
        // Arrange
        var utcNow = DateTimeOffset.UtcNow;

        // Act
        var timeProviderUtcNow = DateTimeProvider.GetDate();

        // Assert
        timeProviderUtcNow.Should().BeAfter(utcNow);
    }
    [Fact]
    public void DateTimeProvider_Should_Return_GetDateCustomFuncion()
    {
        // Arrange
        var utcNow = DateTimeOffset.UtcNow;

        // Act
        DateTimeProvider.GetDateCustomFunction = new Func<DateTimeOffset>(() => utcNow);
        var timeProviderUtcNow = DateTimeProvider.GetDate();

        // Assert
        timeProviderUtcNow.Should().Be(utcNow);
    }
}
