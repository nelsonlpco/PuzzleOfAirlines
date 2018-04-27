using System.Collections.Generic;
using System.Xml.Schema;
using CodeItAirLines.CrossCutting.Notificators;
using CodeItAirLines.CrossCutting.Resources;
using CodeItAirLines.Domain.BoardingAreas;

namespace CodeItAirLines.Domain.Rules
{
    public class PrisonerRule : Validator, IRule
    {
        public void CheckRules(IBoardingArea boardingArea)
        {
            CheckIfPrisonerIsAloneWithPassengers(boardingArea);
        }

        public List<string> GetErrors() => Errors;

        private void CheckIfPrisonerIsAloneWithPassengers(IBoardingArea boardingArea)
        {
            var prisonerIsAlone = boardingArea.GetBoardingAreaManager().PrisonerIsPresent() &&
                                  !boardingArea.GetBoardingAreaManager().CoopIsPresent() &&
                                  boardingArea.GetBoardingAreaManager().CountPassengers() > 1;

            if (prisonerIsAlone)
                AddError(ErrorMessages.PrisonerNotAloneWithPassengers);
        }
    }
}