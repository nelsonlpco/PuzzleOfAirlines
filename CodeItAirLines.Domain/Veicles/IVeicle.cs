using System.Collections.Generic;
using CodeItAirLines.Domain.BoardingAreas;
using CodeItAirLines.Domain.Passengers;

namespace CodeItAirLines.Domain.Veicles
{
    public interface IVeicle : IBoardingArea
    {
        void SetDriver(IPassenger driver);
        void SetPassenger(IPassenger passenger);
        void GoToAirplane();
        void GoToDepartureGate();
        bool IsValid();
        List<string> GetErrors();
    }
}