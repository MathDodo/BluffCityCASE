using System;

namespace BluffCityCase
{
    public class Router
    {
        private static Router _instance;

        public static Router Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Router();
                }

                return _instance;
            }
        }

        private Router()
        {
        }

        public void RecieveAndRoute()
        {
            var data = AirportManager.Instance.ReceiveMessagesFromQueue(AirportManager.ROUTER_FOR_INFORMATION_DATA_TO_COMPANIES);

            for (int i = 0; i < data.Length; i++)
            {
                var company = AirportManager.Instance._Companies.Find(c => c.Name == data[i].Label);

                if (company != null)
                {
                    Console.WriteLine("Rerouting to: " + company.Name);
                    AirportManager.Instance.SendMessageToQueue(data[i].Body, data[i].Label, company.MsmqID);
                }
            }
        }
    }
}