using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using CodeItAirLines.CrossCutting.Resources;
using CodeItAirLines.Domain;
using CodeItAirLines.Domain.BoardingAreas;
using CodeItAirLines.Domain.Passengers;
using CodeItAirLines.Domain.Rules;
using CodeItAirLines.Domain.Veicles;

namespace CodeItAirLines.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleAppManager = new ConsoleAppManager();
            var tentar = "s";
            while (tentar == "s")
            {
                Console.Clear();
                Console.WriteLine(SystemMessages.AppName);
                Console.WriteLine("-----------------------------------------------------------------------------");
                Console.WriteLine(SystemMessages.ProblemenDescription);
                Console.WriteLine(SystemMessages.PressKey);
                Console.ReadKey(true);
                Console.Clear();

                consoleAppManager = new ConsoleAppManager();
                while (consoleAppManager.ShowGameOver() == false)
                {
                    Console.Clear();
                    consoleAppManager.SelectDriverAndPassegerForMoveToAirplane();
                    Console.Clear();

                    if (!consoleAppManager.ShowGameOver())
                        consoleAppManager.SelectDriverAndPassegerForMoveToDepartureGate();
                }

                Console.WriteLine($"\n\n{SystemMessages.TryAgain}");
                tentar = Console.ReadKey().KeyChar.ToString();
            }
        }
    }
}