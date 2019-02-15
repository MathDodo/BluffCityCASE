using System;

namespace BluffCityCase
{
    [Serializable]
    public struct AirTrafficControlCenterData
    {
        public string To { get; set; }
        public string From { get; set; }
        public string Airline { get; set; }
        public string Aircraft { get; set; }
        public string FlightNumber { get; set; }
        public Time ExpectedTakeoff { get; set; }

        public AirTrafficControlCenterData(string to, string from, string airline, string aircraft, string flightNumber, Time expectedTakeoff)
        {
            To = to;
            From = from;
            Airline = airline;
            Aircraft = aircraft;
            FlightNumber = flightNumber;
            ExpectedTakeoff = expectedTakeoff;
        }
    }
}