using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CodeItAirLines.CrossCutting.Notificators;
using CodeItAirLines.CrossCutting.Resources;
using CodeItAirLines.Domain.BoardingAreas;
using CodeItAirLines.Domain.Passengers;
using CodeItAirLines.Domain.Rules;

namespace CodeItAirLines.Domain.Veicles
{
    public class SmartFortwo : Validator, IVeicle
    {
        private readonly IBoardingArea _departurGate;
        private readonly IBoardingArea _airplane;
        private readonly IBoardingAreaManager _boardingAreaManager;

        public SmartFortwo(IBoardingArea departurGate, IBoardingArea airplane)
        {
            _departurGate = departurGate;
            _airplane = airplane;
            _boardingAreaManager = new BoardingAreaManager();
        }

        public void SetDriver(IPassenger driver)
        {
            if (driver == null)
            {
                AddError(ErrorMessages.DriverIsRequired);
                return;
            }

            if (!driver.DriverPerform())
                AddError(string.Format(ErrorMessages.PassengerCanNotDrive, driver.ToString()));

            _boardingAreaManager.AddPassenger(driver);
        }

        public void SetPassenger(IPassenger passenger)
        {
            if (passenger != null)
                _boardingAreaManager.AddPassenger(passenger);
        }


        public void GoToAirplane()
        {
            if (DriverIsNotPresent())
                return;

            if (_boardingAreaManager.CountPassengers() != 2)
                return;

            _airplane.GetBoardingAreaManager().AddPassengers(_boardingAreaManager.GetPassengers().ToList());
            _boardingAreaManager.RemoveAllPassengers();
        }

        public void GoToDepartureGate()
        {
            if (DriverIsNotPresent())
                return;

            _departurGate.GetBoardingAreaManager().AddPassengers(_boardingAreaManager.GetPassengers().ToList());
            _boardingAreaManager.RemoveAllPassengers();
        }

        public List<string> GetErrors() => Errors;

        public IBoardingAreaManager GetBoardingAreaManager() => _boardingAreaManager;

        private bool DriverIsNotPresent()
        {
            var driverIsNotPresent = !_boardingAreaManager.DriverIsPresent();
            if (!_boardingAreaManager.DriverIsPresent())
                AddError(ErrorMessages.DriverIsRequired);

            return driverIsNotPresent;
        }
    }
}