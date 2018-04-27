using System.Collections.Generic;
using CodeItAirLines.Domain.BoardingAreas;
using CodeItAirLines.Domain.Passengers;
using CodeItAirLines.Domain.Tests.Builders;
using FluentAssertions;
using Xunit;

namespace CodeItAirLines.Domain.Tests.BoardingAreas
{
    public class DepartureGateTest
    {
        [Fact]
        public void should_be_instantiat_a_valid_departure_gate()
        {
            var passengers = new List<IPassenger>()
            {
                new PassengerBuilder().IsCabinChief().Create()
            };

            var departureGate = new DepartureGate(passengers);
            departureGate.Should().NotBeNull();
        }
    }
}