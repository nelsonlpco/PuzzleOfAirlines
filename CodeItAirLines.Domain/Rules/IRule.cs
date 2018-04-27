using System.Collections.Generic;
using CodeItAirLines.Domain.BoardingAreas;

namespace CodeItAirLines.Domain.Rules
{
    public interface IRule
    {
        void CheckRules(IBoardingArea boardingArea);
        List<string> GetErrors();
        bool IsValid();
    }
}