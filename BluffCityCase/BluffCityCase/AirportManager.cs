using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;

namespace BluffCityCase
{
    public class AirportManager
    {
        private const string PRIVATE_PATH = @".\Private$\BluffCityAirportCase";

        public const int ROUTER_FOR_INFORMATION_DATA_TO_COMPANIES = 0;
        public const string ROUTED_TO_COMPANY_PATH = PRIVATE_PATH + "CompanyInformationData";

        private int _currentID;
        private static AirportManager _instance;
        private List<MessageQueue> _messageQueues;

        public List<AirlineCompany> _Companies;

        public static AirportManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new AirportManager();
                }

                return _instance;
            }
        }

        private AirportManager()
        {
            _Companies = new List<AirlineCompany>();

            _messageQueues = new List<MessageQueue>();

            _messageQueues.Add(CreateQueue(PRIVATE_PATH + "InformationDataRouter", typeof(AirportInformationCenterData)));

            _currentID = _messageQueues.Count;

            AddNewCompany("KLM");
            AddNewCompany("SAS");
            AddNewCompany("South West Airlines");
        }

        private MessageQueue CreateQueue(string queueName, Type dataType)
        {
            MessageQueue msMq = null;

            // check if queue exists, if not create it
            if (!MessageQueue.Exists(queueName))
            {
                msMq = MessageQueue.Create(queueName);
            }
            else

            {
                msMq = new MessageQueue(queueName);
            }

            msMq.Formatter = (IMessageFormatter)Activator.CreateInstance(typeof(JsonMessageFormatter<>).MakeGenericType(new Type[] { dataType }));

            return msMq;
        }

        public void SendMessageToQueue<T>(T data, string label, int targetReciever)
        {
            _messageQueues[targetReciever].Send(data, label);
        }

        public Message[] ReceiveMessagesFromQueue(int msmqID)
        {
            var returned = _messageQueues[msmqID].GetAllMessages();
            _messageQueues[msmqID].Purge();
            return returned;
        }

        public T[] ReceiveDataFromQueue<T>(int msmqID)
        {
            Message[] messages = _messageQueues[msmqID].GetAllMessages();
            T[] returned = new T[messages.Length];

            for (int i = 0; i < messages.Length; i++)
            {
                try
                {
                    returned[i] = (T)messages[i].Body;
                }
                catch (MessageQueueException ee)
                {
                    Console.Write(ee.ToString());
                }
                catch (Exception eee)
                {
                    Console.Write(eee.ToString());
                }
            }

            _messageQueues[msmqID].Purge();

            return returned;
        }

        public void AddNewCompany(string name)
        {
            if (!_Companies.Any(c => c.Name == name))
            {
                _messageQueues.Add(CreateQueue(ROUTED_TO_COMPANY_PATH + name, typeof(AirportInformationCenterData)));

                _Companies.Add(new AirlineCompany(name, _currentID));

                _currentID++;
            }
        }
    }
}