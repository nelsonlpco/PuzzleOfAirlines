using CodeItAirLines.Domain.DriveBehaviors;
using CodeItAirLines.Domain.Passengers;

namespace CodeItAirLines.Domain.Tests.Builders
{
    public class PassengerBuilder
    {
        private IDriveBehavior _driveBehavior;
        private EPassengerType _passengerType;

        public PassengerBuilder()
        {
            _driveBehavior = new Drive();
            _passengerType = EPassengerType.Pilot;
        }

        public IPassenger Create()
        {
            return new Passenger(_passengerType, _driveBehavior);
        }

        public PassengerBuilder IsCabinChief()
        {
            _passengerType = EPassengerType.CabinChief;
            return this;
        }

        public PassengerBuilder Isdriver()
        {
            _driveBehavior = new Drive();
            return this;
        }

        public PassengerBuilder IsCop()
        {
            _passengerType = EPassengerType.PoliceOfficer;
            return this;
        }

        public PassengerBuilder IsPilot()
        {
            _passengerType = EPassengerType.Pilot;
            return this;
        }

        public PassengerBuilder IsStewardess()
        {
            _passengerType = EPassengerType.Stewardess;
            return this;
        }

        public PassengerBuilder IsPrisoner()
        {
            _passengerType = EPassengerType.Prisoner;
            return this;
        }

        public PassengerBuilder IsFlightOfficer()
        {
            _passengerType = EPassengerType.FlightOfficer;
            return this;
        }
    }
}