using System;

namespace BluffCityCase
{
    [Serializable]
    public struct AirlineCompanyData
    {
        public string To { get; set; }
        public Time Time { get; set; }
        public Time CheckIn { get; set; }
        public string Airline { get; set; }
        public string FlightNumber { get; set; }
        public CheckInStatus CheckInStatus { get; set; }

        public AirlineCompanyData(string to, Time checkIn, Time time, string airline, string flightNumber, CheckInStatus checkInStatus)
        {
            To = to;
            CheckIn = checkIn;
            Time = time;
            Airline = airline;
            FlightNumber = flightNumber;
            CheckInStatus = checkInStatus;
        }

        public override string ToString()
        {
            return "Flightnumber: " + FlightNumber.ToString() + " Airline: " + Airline + " Flying to: " + To + " Check in: " + CheckIn.ToString() + " Time?: " + Time.ToString() + " Check in status: " + CheckInStatus.ToString();
        }
    }
}