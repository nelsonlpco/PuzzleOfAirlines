using CodeItAirLines.CrossCutting.Resources;

namespace CodeItAirLines.Domain.Passengers
{
    public class PassengerTypeTranslator : IPassengerTypeTranslator
    {
        public string Translate(EPassengerType type)
        {
            switch (type)
            {
                case EPassengerType.CabinChief: return SystemMessages.CabinChief;
                case EPassengerType.Pilot: return SystemMessages.Pilot;
                case EPassengerType.FlightOfficer: return SystemMessages.FlightOfficer;
                case EPassengerType.None: return SystemMessages.None;
                case EPassengerType.Stewardess: return SystemMessages.Stewardess;
                case EPassengerType.PoliceOfficer: return SystemMessages.PoliceOfficer;
                case EPassengerType.Prisoner: return SystemMessages.Prisoner;
                default: return string.Empty;
            }
        }
    }
}