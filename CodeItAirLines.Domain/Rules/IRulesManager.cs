using System.Collections.Generic;
using CodeItAirLines.Domain.BoardingAreas;

namespace CodeItAirLines.Domain.Rules
{
    public interface IRulesManager
    {
        void ValidateRules();

        void AddRule(IRule rule);

        List<string> GetErrors();

        bool IsValid();
    }
}