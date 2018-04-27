using CodeItAirLines.Domain.DriveBehaviors;
using FluentAssertions;
using Xunit;

namespace CodeItAirLines.Domain.Tests.DriveBehaviors
{
    public class DriverTest
    {
        [Fact]
        public void should_start_driving()
        {
            new Drive().StartDrive().Should().BeTrue();
        }
    }
}