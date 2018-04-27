using System;
using CodeItAirLines.Domain.DriveBehaviors;

namespace CodeItAirLines.Domain.Passengers
{
    public class Passenger : IPassenger
    {
        public Passenger(EPassengerType passengerType, IDriveBehavior driveBehavior)
        {
            Id = Guid.NewGuid();
            _passegerTypeTranslator = new PassengerTypeTranslator();
            _passengerType = passengerType;
            _driveBehavior = driveBehavior;
        }

        private readonly EPassengerType _passengerType;
        private readonly IDriveBehavior _driveBehavior;
        private readonly IPassengerTypeTranslator _passegerTypeTranslator;
        public Guid Id { get; }

        public EPassengerType GetPassengerType()
        {
            return _passengerType;
        }

        public bool DriverPerform()
        {
            return _driveBehavior.StartDrive();
        }

        public override string ToString()
        {
            return _passegerTypeTranslator.Translate(_passengerType);
        }
    }
}