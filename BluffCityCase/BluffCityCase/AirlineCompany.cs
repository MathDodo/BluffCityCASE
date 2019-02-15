using System;

namespace BluffCityCase
{
    public class AirlineCompany
    {
        public int MsmqID { get; private set; }
        public string Name { get; private set; }

        public AirlineCompany(string company, int msmqID)
        {
            Name = company;
            this.MsmqID = msmqID;
        }

        public void RecieveInformationData()
        {
            var data = AirportManager.Instance.ReceiveDataFromQueue<AirportInformationCenterData>(MsmqID);

            for (int i = 0; i < data.Length; i++)
            {
                Console.WriteLine("Flightnumber: " + data[i].FlightNumber + " Going to: " + data[i].To + " by airline " + Name + " will be at gate: " + data[i].Gate);
            }
        }
    }
}