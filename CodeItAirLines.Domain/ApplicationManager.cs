using CodeItAirLines.CrossCutting.Notificators;
using CodeItAirLines.Domain.BoardingAreas;
using CodeItAirLines.Domain.Passengers;
using CodeItAirLines.Domain.Rules;
using CodeItAirLines.Domain.Veicles;
using System.Collections.Generic;
using System.Linq;

namespace CodeItAirLines.Domain
{
    public class ApplicationManager : Validator
    {
        private readonly IBoardingArea _airplane;
        private readonly IBoardingArea _departureGate;
        private readonly IVeicle _smarthFortwo;
        private readonly List<IRulesManager> _rulesManager;

        public IPassengerTypeTranslator TypeTranslator { get; }

        public ApplicationManager()
        {
            _airplane = new Airplane();
            _departureGate = new DepartureGate(InitializePassengers());
            _smarthFortwo = new SmartFortwo(_departureGate, _airplane);
            TypeTranslator = new PassengerTypeTranslator();

            _rulesManager = new List<IRulesManager>
            {
                new RulesManager(_airplane),
                new RulesManager(_departureGate),
                new RulesManager(_smarthFortwo)
            };
        }

        public List<IPassenger> GetDeparturePassengers() =>
            _departureGate.GetBoardingAreaManager().GetPassengers().ToList();

        public List<IPassenger> GetAirplanePassengers() =>
            _airplane.GetBoardingAreaManager().GetPassengers().ToList();

        private List<IPassenger> InitializePassengers()
        {
            var passengerFactory = new PassengerFactory();
            return new List<IPassenger>
            {
                passengerFactory.MakePassenger(EPassengerType.Pilot),
                passengerFactory.MakePassenger(EPassengerType.FlightOfficer),
                passengerFactory.MakePassenger(EPassengerType.FlightOfficer),
                passengerFactory.MakePassenger(EPassengerType.CabinChief),
                passengerFactory.MakePassenger(EPassengerType.Stewardess),
                passengerFactory.MakePassenger(EPassengerType.Stewardess),
                passengerFactory.MakePassenger(EPassengerType.PoliceOfficer),
                passengerFactory.MakePassenger(EPassengerType.Prisoner)
            };
        }

        public void RulesPerform()
        {
            _rulesManager.ForEach(x =>
            {
                x.ValidateRules();
                AddErrors(x.GetErrors());
            });
        }

        public void MoveToDepartureToAirplane(EPassengerType driverType, EPassengerType passengerType)
        {
            var driver = _departureGate.GetBoardingAreaManager().GetPassengerByType(driverType);
            var passenger = _departureGate.GetBoardingAreaManager().GetPassengerByType(passengerType);

            _smarthFortwo.SetDriver(driver);
            _smarthFortwo.SetPassenger(passenger);

            RulesPerform();

            AddErrors(_smarthFortwo.GetErrors());

            if (IsValid())
            {
                _smarthFortwo.GoToAirplane();
                RulesPerform();
                AddErrors(_smarthFortwo.GetErrors());
            }
        }

        public void MoveToAirplaneToDepartureGate(EPassengerType driverType, EPassengerType passengerType)
        {
            var driver = _airplane.GetBoardingAreaManager().GetPassengerByType(driverType);
            var passenger = _airplane.GetBoardingAreaManager().GetPassengerByType(passengerType);

            _smarthFortwo.SetDriver(driver);
            _smarthFortwo.SetPassenger(passenger);

            RulesPerform();
            AddErrors(_smarthFortwo.GetErrors());

            if (IsValid())
            {
                _smarthFortwo.GoToDepartureGate();
                RulesPerform();
                AddErrors(_smarthFortwo.GetErrors());
            }
        }

        public bool GameOver() => !IsValid() || _airplane.GetBoardingAreaManager().CountPassengers() == 8;
    }
}