using System;

namespace BluffCityCase
{
    [Serializable]
    public struct AirportInformationCenterData
    {
        public int Gate { get; set; }
        public Time Time { get; set; }
        public string To { get; set; }
        public Time Expected { get; set; }
        public string Airline { get; set; }
        public FlightStatus Status { get; set; }
        public string FlightNumber { get; set; }

        public AirportInformationCenterData(int gate, Time time, string to, Time expected, string airline, FlightStatus status, string flightNumber)
        {
            Gate = gate;
            Time = time;
            To = to;
            Expected = expected;
            Airline = airline;
            Status = status;
            FlightNumber = flightNumber;
        }

        public override string ToString()
        {
            return "Flightnumber: " + FlightNumber.ToString() + " From gate: " + Gate.ToString() + " Flying to: " + To + " Exspected: " + Expected.ToString() + " Time?: " + Time.ToString() + " Airline: " + Airline + " The flight status is: " + Status.ToString();
        }
    }
}