using System.Collections.Generic;
using CodeItAirLines.Domain.Passengers;

namespace CodeItAirLines.Domain.BoardingAreas
{
    public class DepartureGate : IBoardingArea
    {
        private readonly IBoardingAreaManager _boardingAreaManager;

        public DepartureGate()
        {
            _boardingAreaManager = new BoardingAreaManager();
        }

        public DepartureGate(List<IPassenger> passengers)
        {
            _boardingAreaManager = new BoardingAreaManager(passengers);
        }

        public IBoardingAreaManager GetBoardingAreaManager() => _boardingAreaManager;
    }
}