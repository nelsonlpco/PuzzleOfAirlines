using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using CodeItAirLines.CrossCutting.Notificators;
using CodeItAirLines.Domain.BoardingAreas;

namespace CodeItAirLines.Domain.Rules
{
    public class RulesManager : Validator, IRulesManager
    {
        private readonly List<IRule> _rules;
        private readonly IBoardingArea _boardingArea;

        public RulesManager(IBoardingArea boardingArea)
        {
            _rules = new List<IRule>() {new FlightOfficerRule(), new PrisonerRule(), new StewardessRule()};
            _boardingArea = boardingArea;
        }

        public RulesManager(IBoardingArea boardingArea, params IRule[] rules)
        {
            _boardingArea = boardingArea;
            _rules = new List<IRule>(rules);
        }

        public void ValidateRules()
        {
            _rules.ForEach(x => x.CheckRules(_boardingArea));
            _rules.ForEach(x => AddErrors(x.GetErrors()));
        }

        public void AddRule(IRule rule) => _rules.Add(rule);
        public List<string> GetErrors() => Errors;
    }
}