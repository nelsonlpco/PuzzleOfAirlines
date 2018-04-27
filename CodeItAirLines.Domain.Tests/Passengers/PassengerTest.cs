using CodeItAirLines.Domain.DriveBehaviors;
using CodeItAirLines.Domain.Passengers;
using FluentAssertions;
using Xunit;

namespace CodeItAirLines.Domain.Tests.Passengers
{
    public class PassengerTest
    {
        [Fact]
        public void should_be_instantiate_a_valid_driver_passenger()
        {
            var passenger = new Passenger(EPassengerType.Pilot, new Drive());

            passenger.GetPassengerType().Should().Be(EPassengerType.Pilot);
            passenger.DriverPerform().Should().BeTrue();
        }

        [Fact]
        public void should_be_instantiate_a_valid_not_driver_passenger()
        {
            var passenger = new Passenger(EPassengerType.Prisoner, new NotDrive());

            passenger.GetPassengerType().Should().Be(EPassengerType.Prisoner);
            passenger.DriverPerform().Should().BeFalse();
        }
    }
}