using System.Collections.Generic;
using CodeItAirLines.Domain.Passengers;

namespace CodeItAirLines.Domain.BoardingAreas
{
    public interface IBoardingAreaManager
    {
        bool PilotIsPresent();
        bool PrisonerIsPresent();
        bool CoopIsPresent();
        bool CabinChiefIsPresent();
        bool DriverIsPresent();
        int CountStewardesses();
        int CountFlightOfficers();
        int CountPassengers();
        void SetPassengers(IList<IPassenger> passengers);
        void AddPassenger(IPassenger passenger);
        void AddPassengers(List<IPassenger> passengers);
        void RemovePassenger(IPassenger passenger);
        void RemoveAllPassengers();
        IReadOnlyList<IPassenger> GetPassengers();
        IPassenger GetPassengerByType(EPassengerType type);
    }
}