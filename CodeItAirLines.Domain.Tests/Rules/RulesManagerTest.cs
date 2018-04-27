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
    public class RulesManagerTest
    {
        [Fact]
        public void should_be_a_valid_rule()
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

            var airplane = new Airplane(passengers);

            var rulesManager = new RulesManager(airplane);
            rulesManager.ValidateRules();

            rulesManager.IsValid().Should().BeTrue();
            rulesManager.Errors.Should().BeEmpty();
        }

        [Fact]
        public void should_be_return_invalid_rule_if_prisoner_are_alone_with_passengers()
        {
            var passengers = new List<IPassenger>()
            {
                new PassengerBuilder().IsPilot().Create(),
                new PassengerBuilder().IsCabinChief().Create(),
                new PassengerBuilder().IsPrisoner().Create(),
                new PassengerBuilder().IsStewardess().Create(),
                new PassengerBuilder().IsStewardess().Create(),
                new PassengerBuilder().IsFlightOfficer().Create(),
                new PassengerBuilder().IsFlightOfficer().Create()
            };

            var airplane = new Airplane(passengers);

            var rulesManager = new RulesManager(airplane);
            rulesManager.ValidateRules();

            rulesManager.IsValid().Should().BeFalse();
            rulesManager.Errors.Any().Should().BeTrue();
        }

        [Fact]
        public void should_be_return_invalid_rules_if_cabin_chief_are_alone_with_flight_official()
        {
            var passengers = new List<IPassenger>()
            {
                new PassengerBuilder().IsCabinChief().Create(),
                new PassengerBuilder().IsFlightOfficer().Create()
            };

            var airplane = new Airplane(passengers);

            var rulesManager = new RulesManager(airplane);
            rulesManager.ValidateRules();

            rulesManager.IsValid().Should().BeFalse();
            rulesManager.Errors.Any().Should().BeTrue();
        }

        [Fact]
        public void should_be_return_invalid_rules_if_pilot_are_alone_with_stewardess()
        {
            var passengers = new List<IPassenger>()
            {
                new PassengerBuilder().IsPilot().Create(),
                new PassengerBuilder().IsStewardess().Create()
            };

            var airplane = new Airplane(passengers);

            var rulesManager = new RulesManager(airplane);
            rulesManager.ValidateRules();

            rulesManager.IsValid().Should().BeFalse();
            rulesManager.Errors.Any().Should().BeTrue();
        }
    }
}