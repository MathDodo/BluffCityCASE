using System;
using System.Collections.Generic;
using System.Linq;

namespace BluffCityCase
{
    internal class Program
    {
        private static int _currentSelection = 0;
        private static Random _randy = new Random();
        private static Dictionary<string, Action> _firstWindowOptions;

        private static void Main(string[] args)
        {
            _firstWindowOptions = new Dictionary<string, Action>();
            _firstWindowOptions.Add("Airport Information Center", AirportInfo);
            _firstWindowOptions.Add("Company Router", Reroute);

            for (int i = 0; i < AirportManager.Instance._Companies.Count; i++)
            {
                _firstWindowOptions.Add(AirportManager.Instance._Companies[i].Name, Company);
            }

            RunMenu();

            //new AirportInformationCenter().SendData();

            //for (int i = 0; i < AirportManager.Instance.Companies.Count; i++)
            //{
            //    AirportManager.Instance.Companies[i].RecieveInformationData();
            //}

            //new Router().RecieveAndRoute();

            Console.WriteLine("Executed");
            Console.ReadKey();
        }

        private static void Company()
        {
            AirportManager.Instance._Companies[_currentSelection - 2].RecieveInformationData();

            Console.ReadKey();
        }

        private static void Reroute()
        {
            Router.Instance.RecieveAndRoute();

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
        }

        private static void AirportInfo()
        {
            Console.WriteLine("Generated data for airline company: " + AirportInformationCenter.Instance.SendData(_randy).ToString() + " will now be sent to router \nPress any key to continue");
            Console.ReadKey();
        }

        private static void RunMenu()
        {
            bool run = true;

            while (run)
            {
                for (int i = 0; i < _firstWindowOptions.Count; i++)
                {
                    if (i == _currentSelection)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }

                    Console.WriteLine(_firstWindowOptions.Keys.ElementAt(i));
                }

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        _currentSelection--;
                        if (_currentSelection < 0) _currentSelection = _firstWindowOptions.Count - 1;

                        break;

                    case ConsoleKey.DownArrow:
                        _currentSelection++;
                        if (_currentSelection >= _firstWindowOptions.Count) _currentSelection = 0;
                        break;

                    case ConsoleKey.Enter:
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.White;
                        _firstWindowOptions[_firstWindowOptions.Keys.ElementAt(_currentSelection)].Invoke();
                        break;

                    case ConsoleKey.Escape:
                        run = false;
                        Console.ForegroundColor = ConsoleColor.White;
                        break;
                }

                Console.Clear();
            }
        }
    }
}