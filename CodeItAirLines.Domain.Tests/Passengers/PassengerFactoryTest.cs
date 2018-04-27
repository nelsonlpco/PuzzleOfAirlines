using CodeItAirLines.Domain.Passengers;
using FluentAssertions;
using Xunit;

namespace CodeItAirLines.Domain.Tests.Passengers
{
    public class PassengerFactoryTest
    {
        [Fact]
        public void should_be_make_a_cop()
        {
            var cop = new PassengerFactory().MakePassenger(EPassengerType.PoliceOfficer);
            cop.GetPassengerType().Should().Be(EPassengerType.PoliceOfficer);
            cop.DriverPerform().Should().BeTrue();
        }

        [Fact]
        public void should_be_make_a_prisoner()
        {
            var cop = new PassengerFactory().MakePassenger(EPassengerType.Prisoner);
            cop.GetPassengerType().Should().Be(EPassengerType.Prisoner);
            cop.DriverPerform().Should().BeFalse();
        }

        [Fact]
        public void should_be_make_a_pilot()
        {
            var cop = new PassengerFactory().MakePassenger(EPassengerType.Pilot);
            cop.GetPassengerType().Should().Be(EPassengerType.Pilot);
            cop.DriverPerform().Should().BeTrue();
        }

        [Fact]
        public void should_be_make_a_cabin_chief()
        {
            var cop = new PassengerFactory().MakePassenger(EPassengerType.CabinChief);
            cop.GetPassengerType().Should().Be(EPassengerType.CabinChief);
            cop.DriverPerform().Should().BeTrue();
        }

        [Fact]
        public void should_be_make_a_flight_officer()
        {
            var cop = new PassengerFactory().MakePassenger(EPassengerType.FlightOfficer);
            cop.GetPassengerType().Should().Be(EPassengerType.FlightOfficer);
            cop.DriverPerform().Should().BeFalse();
        }

        [Fact]
        public void should_be_make_a_stewardess()
        {
            var cop = new PassengerFactory().MakePassenger(EPassengerType.Stewardess);
            cop.GetPassengerType().Should().Be(EPassengerType.Stewardess);
            cop.DriverPerform().Should().BeFalse();
        }
    }
}