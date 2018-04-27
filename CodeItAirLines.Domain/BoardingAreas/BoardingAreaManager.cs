using System.Collections.Generic;
using System.Linq;
using CodeItAirLines.Domain.Passengers;

namespace CodeItAirLines.Domain.BoardingAreas
{
    public class BoardingAreaManager : IBoardingAreaManager
    {
        private readonly List<IPassenger> _passengers;

        public BoardingAreaManager(List<IPassenger> passengers)
        {
            _passengers = passengers;
        }

        public BoardingAreaManager()
        {
            _passengers = new List<IPassenger>();
        }

        public bool PilotIsPresent() =>
            _passengers.Any(x => x.GetPassengerType() == EPassengerType.Pilot);

        public bool PrisonerIsPresent() =>
            _passengers.Any(x => x.GetPassengerType() == EPassengerType.Prisoner);

        public bool CoopIsPresent() =>
            _passengers.Any(x => x.GetPassengerType() == EPassengerType.PoliceOfficer);

        public bool CabinChiefIsPresent() =>
            _passengers.Any(x => x.GetPassengerType() == EPassengerType.CabinChief);

        public int CountStewardesses() =>
            _passengers.Count(x => x.GetPassengerType() == EPassengerType.Stewardess);

        public int CountFlightOfficers() =>
            _passengers.Count(x => x.GetPassengerType() == EPassengerType.FlightOfficer);

        public bool DriverIsPresent() => _passengers.Any(x => x.DriverPerform());

        public int CountPassengers() => _passengers.Count;
        public void SetPassengers(IList<IPassenger> passengers) => _passengers.AddRange(passengers);

        public void AddPassenger(IPassenger passenger) => _passengers.Add(passenger);
        public void AddPassengers(List<IPassenger> passengers) => _passengers.AddRange(passengers);

        public void RemovePassenger(IPassenger passenger) => _passengers.Remove(passenger);
        public void RemoveAllPassengers() => _passengers.Clear();
        public IReadOnlyList<IPassenger> GetPassengers() => _passengers.AsReadOnly();

        public IPassenger GetPassengerByType(EPassengerType type)
        {
            var passenger = _passengers.Find(x => x.GetPassengerType() == type);
            _passengers.Remove(passenger);
            return passenger;
        }
    }
}