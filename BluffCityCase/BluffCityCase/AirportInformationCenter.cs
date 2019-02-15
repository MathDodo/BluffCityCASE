using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BluffCityCase
{
    public class AirportInformationCenter
    {
        private int _gates = 42;
        private List<string> _destinations;

        private static AirportInformationCenter _instance;

        public static AirportInformationCenter Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AirportInformationCenter();
                }

                return _instance;
            }
        }

        private AirportInformationCenter()
        {
            _destinations = new List<string>();
            _destinations.Add("Amsterdam");
            _destinations.Add("Copenhagen");
            _destinations.Add("Boston");
            _destinations.Add("Berlin");
            _destinations.Add("London Heathrow");
        }

        public AirportInformationCenterData SendData(Random randy)
        {
            int hour = randy.Next(0, 24);
            int minute = randy.Next(0, 59);
            var comp = AirportManager.Instance._Companies[randy.Next(0, AirportManager.Instance._Companies.Count)].Name;

            var data = new AirportInformationCenterData(randy.Next(1, _gates), new Time(hour, minute), _destinations[randy.Next(0, _destinations.Count)],
                new Time(hour, minute + randy.Next(0, 25)), comp, FlightStatus.Boarding, comp.Substring(0, 2) + randy.Next(1000, 10000).ToString());

            AirportManager.Instance.SendMessageToQueue(data, comp, AirportManager.ROUTER_FOR_INFORMATION_DATA_TO_COMPANIES);

            return data;
        }
    }
}