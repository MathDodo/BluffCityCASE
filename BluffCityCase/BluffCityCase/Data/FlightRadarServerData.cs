using System;

namespace BluffCityCase
{
    [Serializable]
    public struct FlightRadarServerData
    {
        public string To { get; set; }
        public string From { get; set; }
        public float Latitude { get; set; }
        public int SpeedKnots { get; set; }
        public string Airline { get; set; }
        public string Aircraft { get; set; }
        public float Longtitude { get; set; }
        public int AltitudeFeet { get; set; }
        public int TrackDegrees { get; set; }
        public string FlightNumber { get; set; }
        public Time EstimatedArrival { get; set; }

        public FlightRadarServerData(string to, string from, float latitude, float longtitude, int speedKnots, string airline, string aircraft, int altitudeFeet, string flightNumber, Time estimatedArrival, int trackDegrees)
        {
            To = to;
            From = from;
            Latitude = latitude;
            Longtitude = longtitude;
            SpeedKnots = speedKnots;
            Airline = airline;
            Aircraft = aircraft;
            AltitudeFeet = altitudeFeet;
            FlightNumber = flightNumber;
            EstimatedArrival = estimatedArrival;
            TrackDegrees = trackDegrees;
        }
    }
}