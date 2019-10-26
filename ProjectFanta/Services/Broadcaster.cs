using System.Collections.Generic;
using ProjectFanta.Services.Interfaces;

namespace ProjectFanta.Services 
{

    public class Broadcaster : IBroadcaster
    {
        private ITwilioService twilioService;
        private IGroupManager groupManager;

        public void Broadcast(IEnumerable<IUser> subscribers)
        {
            
        }

    }

}