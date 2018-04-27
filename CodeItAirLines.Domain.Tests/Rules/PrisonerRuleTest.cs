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
    public class PrisonerRuleTest
    {
        [Fact]
        public void should_be_valid_if_not_alone_with_the_passengers()
        {
            var passengers = new List<IPassenger>()
            {
                new PassengerBuilder().IsCabinChief().Create(),
                new PassengerBuilder().IsFlightOfficer().Create(),
                new PassengerBuilder().IsStewardess().Create(),
                new PassengerBuilder().IsPrisoner().Create(),
                new PassengerBuilder().IsCop().Create()
            };

            var departureGate = new DepartureGate(passengers);

            var rule = new PrisonerRule();
            rule.CheckRules(departureGate);

            rule.IsValid().Should().BeTrue();
            rule.Errors.Should().BeEmpty();


            passengers = new List<IPassenger>()
            {
                new PassengerBuilder().IsPrisoner().Create(),
                new PassengerBuilder().IsCop().Create()
            };
            departureGate = new DepartureGate(passengers);
            rule.CheckRules(departureGate);

            rule.IsValid().Should().BeTrue();
            rule.Errors.Should().BeEmpty();
        }

        [Fact]
        public void should_be_invalid_if_prisoner_is_alone_with_the_passengers()
        {
            var passengers = new List<IPassenger>()
            {
                new PassengerBuilder().IsCabinChief().Create(),
                new PassengerBuilder().IsFlightOfficer().Create(),
                new PassengerBuilder().IsPrisoner().Create()
            };

            var departureGate = new DepartureGate(passengers);

            var rule = new PrisonerRule();
            ;
            rule.CheckRules(departureGate);

            rule.IsValid().Should().BeFalse();
            rule.Errors.Any().Should().BeTrue();
        }
    }
}