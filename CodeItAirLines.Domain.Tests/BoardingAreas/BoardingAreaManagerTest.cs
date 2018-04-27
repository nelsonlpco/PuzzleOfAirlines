using System.Collections.Generic;
using CodeItAirLines.Domain.BoardingAreas;
using CodeItAirLines.Domain.Passengers;
using CodeItAirLines.Domain.Tests.Builders;
using FluentAssertions;
using Xunit;

namespace CodeItAirLines.Domain.Tests.BoardingAreas
{
    public class BoardingAreaManagerTest
    {
        [Fact]
        public void should_be_true_if_pilot_is_present()
        {
            var passengers = new List<IPassenger>()
            {
                new PassengerBuilder().IsCabinChief().Create(),
                new PassengerBuilder().IsPilot().Create()
            };

            new BoardingAreaManager(passengers).PilotIsPresent().Should().BeTrue();
        }

        [Fact]
        public void should_be_false_if_pilot_is_not_present()
        {
            var passengers = new List<IPassenger>()
            {
                new PassengerBuilder().IsCabinChief().Create()
            };

            new BoardingAreaManager(passengers).PilotIsPresent().Should().BeFalse();
        }

        [Fact]
        public void should_be_true_if_cabin_chief_is_present()
        {
            var passengers = new List<IPassenger>()
            {
                new PassengerBuilder().IsCabinChief().Create(),
                new PassengerBuilder().IsPilot().Create()
            };

            new BoardingAreaManager(passengers).PilotIsPresent().Should().BeTrue();
        }

        [Fact]
        public void should_be_false_if_cabin_chief_is_not_present()
        {
            var passengers = new List<IPassenger>()
            {
                new PassengerBuilder().IsPilot().Create()
            };

            new BoardingAreaManager(passengers).CabinChiefIsPresent().Should().BeFalse();
        }

        [Fact]
        public void should_be_false_if_cop_is_not_present()
        {
            var passengers = new List<IPassenger>()
            {
                new PassengerBuilder().IsPilot().Create()
            };

            new BoardingAreaManager(passengers).CoopIsPresent().Should().BeFalse();
        }

        [Fact]
        public void should_be_true_if_cop_is_present()
        {
            var passengers = new List<IPassenger>()
            {
                new PassengerBuilder().IsPilot().Create(),
                new PassengerBuilder().IsCop().Create()
            };

            new BoardingAreaManager(passengers).CoopIsPresent().Should().BeTrue();
        }

        [Fact]
        public void should_be_false_if_prisoner_is_not_present()
        {
            var passengers = new List<IPassenger>()
            {
                new PassengerBuilder().IsCop().Create()
            };

            new BoardingAreaManager(passengers).PrisonerIsPresent().Should().BeFalse();
        }

        [Fact]
        public void should_be_true_if_prisoner_is_present()
        {
            var passengers = new List<IPassenger>()
            {
                new PassengerBuilder().IsPrisoner().Create(),
                new PassengerBuilder().IsCop().Create()
            };

            new BoardingAreaManager(passengers).PrisonerIsPresent().Should().BeTrue();
        }

        [Fact]
        public void should_be_one_flight_officer()
        {
            var passengers = new List<IPassenger>()
            {
                new PassengerBuilder().IsFlightOfficer().Create(),
                new PassengerBuilder().IsCop().Create()
            };

            new BoardingAreaManager(passengers).CountFlightOfficers().Should().Be(1);
        }

        [Fact]
        public void should_be_one_stewardess()
        {
            var passengers = new List<IPassenger>()
            {
                new PassengerBuilder().IsFlightOfficer().Create(),
                new PassengerBuilder().IsCop().Create(),
                new PassengerBuilder().IsStewardess().Create()
            };

            new BoardingAreaManager(passengers).CountStewardesses().Should().Be(1);
        }

        [Fact]
        public void should_be_eight_passengers()
        {
            var passengers = new List<IPassenger>()
            {
                new PassengerBuilder().IsPilot().Create(),
                new PassengerBuilder().IsCabinChief().Create(),
                new PassengerBuilder().IsCop().Create(),
                new PassengerBuilder().IsPrisoner().Create(),
                new PassengerBuilder().IsStewardess().Create(),
                new PassengerBuilder().IsStewardess().Create(),
                new PassengerBuilder().IsFlightOfficer().Create(),
                new PassengerBuilder().IsFlightOfficer().Create()
            };

            new BoardingAreaManager(passengers).CountPassengers().Should().Be(8);
        }
    }
}