using System;
using System.Collections.Generic;
using CodeItAirLines.CrossCutting.Resources;
using CodeItAirLines.Domain;
using CodeItAirLines.Domain.DriveBehaviors;
using CodeItAirLines.Domain.Passengers;

namespace CodeItAirLines.ConsoleApp
{
    public class ConsoleAppManager
    {
        private readonly ApplicationManager _applicationManager;

        public ConsoleAppManager()
        {
            _applicationManager = new ApplicationManager();
        }

        public Dictionary<short, EPassengerType> MakeOptions(List<IPassenger> passengers, bool showNoneOption = false)
        {
            short index = 0;
            var options = new Dictionary<short, EPassengerType>();

            if (showNoneOption)
                options.Add(0, EPassengerType.None);

            passengers.ForEach(x => options.Add(++index, x.GetPassengerType()));

            return options;
        }

        public void ShowOptions(Dictionary<short, EPassengerType> options)
        {
            foreach (var option in options)
            {
                Console.WriteLine($"{option.Key} - {_applicationManager.TypeTranslator.Translate(option.Value)}");
            }
        }

        public EPassengerType GetOption(Dictionary<short, EPassengerType> options, string menuTitle, string question)
        {
            var isValid = false;
            var result = EPassengerType.None;
            while (!isValid)
            {
                Console.Clear();
                Console.WriteLine(menuTitle);
                Console.WriteLine("------------------------------------------------------");
                ShowOptions(options);

                Console.Write($"\n{question}");
                var validOptionForDriver = short.TryParse(Console.ReadKey().KeyChar.ToString(), out var index);
                if (validOptionForDriver)
                {
                    if (options.ContainsKey(index))
                    {
                        result = options[index];
                        options.Remove(index);
                        isValid = true;
                    }
                }

                if (isValid) continue;

                Console.Beep();
                Console.WriteLine($"\n{ErrorMessages.InvalidResponse}.");
                Console.WriteLine(SystemMessages.PressKey);
                Console.ReadKey(true);
            }

            return result;
        }

        public void SelectDriverAndPassegerForMoveToAirplane()
        {
            var options = MakeOptions(_applicationManager.GetDeparturePassengers());
            var driver = GetOption(options, SystemMessages.DepartureGate, SystemMessages.SelectTheDriver);
            var passenger = GetOption(options, SystemMessages.DepartureGate, SystemMessages.SelectThePassenger);

            _applicationManager.MoveToDepartureToAirplane(driver, passenger);
        }

        public void SelectDriverAndPassegerForMoveToDepartureGate()
        {
            var options = MakeOptions(_applicationManager.GetAirplanePassengers(), true);
            var driver = GetOption(options, SystemMessages.Airplane, SystemMessages.SelectTheDriver);
            var passenger = GetOption(options, SystemMessages.Airplane, SystemMessages.SelectThePassenger);

            _applicationManager.MoveToAirplaneToDepartureGate(driver, passenger);
        }

        public bool ShowGameOver()
        {
            if (!_applicationManager.GameOver()) return false;

            Console.Clear();
            if (_applicationManager.IsValid())
                Console.WriteLine(SystemMessages.Winner);
            else
                _applicationManager.Errors.ForEach(Console.WriteLine);

            return true;
        }
    }
}