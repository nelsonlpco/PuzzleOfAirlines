using System.Collections.Generic;
using CodeItAirLines.CrossCutting.Notificators;
using CodeItAirLines.CrossCutting.Resources;
using CodeItAirLines.Domain.BoardingAreas;

namespace CodeItAirLines.Domain.Rules
{
    public class FlightOfficerRule : Validator, IRule
    {
        public void CheckRules(IBoardingArea boardingArea)
        {
            CheckIfFlightOfficerIsNotAloneWithCabinChief(boardingArea);
        }

        public List<string> GetErrors() => Errors;

        private void CheckIfFlightOfficerIsNotAloneWithCabinChief(IBoardingArea boardingArea)
        {
            var thereAreNotFlightOfficers = boardingArea.GetBoardingAreaManager().CountFlightOfficers() == 0;
            var thereAreMoreThanTwoPeople = boardingArea.GetBoardingAreaManager().CountPassengers() > 2;

            var FlightOfficersNotAlone = thereAreMoreThanTwoPeople || thereAreNotFlightOfficers ||
                                         !boardingArea.GetBoardingAreaManager().CabinChiefIsPresent();

            if (!FlightOfficersNotAlone)
                AddError(ErrorMessages.FlightOfficersNotAloneWithCabinChief);
        }
    }
}