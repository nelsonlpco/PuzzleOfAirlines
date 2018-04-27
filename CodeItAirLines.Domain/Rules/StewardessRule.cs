using System.Collections.Generic;
using CodeItAirLines.CrossCutting.Notificators;
using CodeItAirLines.CrossCutting.Resources;
using CodeItAirLines.Domain.BoardingAreas;

namespace CodeItAirLines.Domain.Rules
{
    public class StewardessRule : Validator, IRule
    {
        public void CheckRules(IBoardingArea boardingArea)
        {
            CheckIfStewardessIsNotAloneWithPilot(boardingArea);
        }

        public List<string> GetErrors() => Errors;

        private void CheckIfStewardessIsNotAloneWithPilot(IBoardingArea boardingArea)
        {
            var thereAreNotStewardess = boardingArea.GetBoardingAreaManager().CountStewardesses() == 0;
            var thereAreMoreThanTwoPeople = boardingArea.GetBoardingAreaManager().CountPassengers() > 2;

            var stewardessIsAlone = thereAreMoreThanTwoPeople || thereAreNotStewardess ||
                                    !boardingArea.GetBoardingAreaManager().PilotIsPresent();

            if (!stewardessIsAlone) AddError(ErrorMessages.StewardessesNotAloneWithPilot);
        }
    }
}