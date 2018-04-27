using System.Collections.Generic;
using System.Linq;

namespace CodeItAirLines.CrossCutting.Notificators
{
    public abstract class Validator
    {
        public List<string> Errors { get; private set; }

        public Validator()
        {
            Errors = new List<string>();
        }

        public void AddError(string error) => Errors.Add(error);

        public void AddErrors(List<string> errors) => Errors.AddRange(errors);

        public bool IsValid() => !Errors.Any();
    }
}