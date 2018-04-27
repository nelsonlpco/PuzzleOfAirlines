using System.Collections.Generic;
using CodeItAirLines.Domain.Passengers;

namespace CodeItAirLines.Domain.BoardingAreas
{
    public class Airplane : IBoardingArea
    {
        private readonly IBoardingAreaManager _boardingAreaManager;

        public Airplane()
        {
            _boardingAreaManager = new BoardingAreaManager();
        }

        public Airplane(List<IPassenger> passengers)
        {
            _boardingAreaManager = new BoardingAreaManager(passengers);
        }

        public IBoardingAreaManager GetBoardingAreaManager() => _boardingAreaManager;
    }
}