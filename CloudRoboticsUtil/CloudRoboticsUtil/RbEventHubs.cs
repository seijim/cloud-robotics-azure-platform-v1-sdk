using System;
using System.Text;
using Microsoft.ServiceBus.Messaging;


namespace CloudRoboticsUtil
{
    public class RbEventHubs
    {
        private string eventHubConnString;
        private string eventHubName;

        public RbEventHubs(string eventHubConnString, string eventHubName)
        {
            this.eventHubConnString = eventHubConnString;
            this.eventHubName = eventHubName;
        }

        public async void SendMessage(string message, string deviceId)
        {
            var eventHubClient = EventHubClient.CreateFromConnectionString(eventHubConnString, eventHubName);
            EventData eventData = new EventData(Encoding.UTF8.GetBytes(message));
            eventData.PartitionKey = deviceId;
            await eventHubClient.SendAsync(eventData);
            await eventHubClient.CloseAsync();
        }

    }
}
