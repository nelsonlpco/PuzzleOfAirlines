using System.Collections.Generic;
using System.Linq;
using CodeItAirLines.Domain.BoardingAreas;
using CodeItAirLines.Domain.Passengers;
using CodeItAirLines.Domain.Rules;
using CodeItAirLines.Domain.Tests.Builders;
using FluentAssertions;
using Xunit;

namespace CodeItAirLines.Domain.Tests.Rules
{
    public class FlightOfficerRuleTest
    {
        [Fact]
        public void should_be_valid_if_not_alone_with_the_cabin_chief()
        {
            var passengers = new List<IPassenger>()
            {
                new PassengerBuilder().IsCabinChief().Create(),
                new PassengerBuilder().IsFlightOfficer().Create(),
                new PassengerBuilder().IsStewardess().Create()
            };

            var departureGate = new DepartureGate(passengers);

            var rule = new FlightOfficerRule();
            rule.CheckRules(departureGate);

            rule.IsValid().Should().BeTrue();
            rule.Errors.Should().BeEmpty();


            passengers = new List<IPassenger>()
            {
                new PassengerBuilder().IsPrisoner().Create(),
                new PassengerBuilder().IsFlightOfficer().Create()
            };
            departureGate = new DepartureGate(passengers);

            rule.CheckRules(departureGate);

            rule.IsValid().Should().BeTrue();
            rule.Errors.Should().BeEmpty();
        }

        [Fact]
        public void should_be_invalid_if_flight_officer_alone_with_the_cabin_chief()
        {
            var passengers = new List<IPassenger>()
            {
                new PassengerBuilder().IsCabinChief().Create(),
                new PassengerBuilder().IsFlightOfficer().Create(),
            };

            var departureGate = new DepartureGate(passengers);

            var rule = new FlightOfficerRule();
            rule.CheckRules(departureGate);

            rule.IsValid().Should().BeFalse();
            rule.Errors.Any().Should().BeTrue();
        }
    }
}