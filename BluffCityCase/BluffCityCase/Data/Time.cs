using System;

namespace BluffCityCase
{
    [Serializable]
    public struct Time
    {
        public int Hour { get; set; }
        public int Minute { get; set; }

        public Time(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }

        public override string ToString()
        {
            return Hour.ToString() + "." + Minute.ToString();
        }
    }
}