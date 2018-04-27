using System.Collections.Generic;
using CodeItAirLines.Domain.BoardingAreas;
using CodeItAirLines.Domain.Passengers;
using CodeItAirLines.Domain.Tests.Builders;
using FluentAssertions;
using Xunit;

namespace CodeItAirLines.Domain.Tests.BoardingAreas
{
    public class AirplaneTest
    {
        [Fact]
        public void should_be_instantiat_a_valid_airplane()
        {
            var passengers = new List<IPassenger>()
            {
                new PassengerBuilder().IsCabinChief().Create()
            };

            var airplane = new Airplane(passengers);


            airplane.Should().NotBeNull();
        }
    }
}