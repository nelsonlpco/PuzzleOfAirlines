using CodeItAirLines.Domain.DriveBehaviors;
using FluentAssertions;
using Xunit;

namespace CodeItAirLines.Domain.Tests.DriveBehaviors
{
    public class NotDriverTest
    {
        [Fact]
        public void should_not_be_able_to_drive()
        {
            new NotDrive().StartDrive().Should().BeFalse();
        }
    }
}