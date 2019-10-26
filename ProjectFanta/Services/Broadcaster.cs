using System.Collections.Generic;
using ProjectFanta.Services.Interfaces;

namespace ProjectFanta.Services 
{

    public class Broadcaster : IBroadcaster
    {
        private ITwilioService twilioService;

        public Broadcaster(ITwilioService twilioService)
        {
            this.twilioService = twilioService;
        }

        public void Broadcast(string broadcastMessage, IGroup group)
        {
            var subscribers = group.Subscribers;
            foreach (var sub in subscribers)
            {
                this.twilioService.SendMessage(sub, broadcastMessage);
            }
        }

    }

}