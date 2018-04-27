using System;
using CodeItAirLines.Domain.DriveBehaviors;

namespace CodeItAirLines.Domain.Passengers
{
    public class PassengerFactory
    {
        public IPassenger MakePassenger(EPassengerType passengerType)
        {
            switch (passengerType)
            {
                case EPassengerType.CabinChief:
                    return new Passenger(EPassengerType.CabinChief, new Drive());
                case EPassengerType.Pilot:
                    return new Passenger(EPassengerType.Pilot, new Drive());
                case EPassengerType.PoliceOfficer:
                    return new Passenger(EPassengerType.PoliceOfficer, new Drive());
                case EPassengerType.FlightOfficer:
                    return new Passenger(EPassengerType.FlightOfficer, new NotDrive());
                case EPassengerType.Stewardess:
                    return new Passenger(EPassengerType.Stewardess, new NotDrive());
                case EPassengerType.Prisoner:
                    return new Passenger(EPassengerType.Prisoner, new NotDrive());
                default:
                    throw new ArgumentOutOfRangeException(nameof(passengerType), passengerType, null);
            }
        }
    }
}