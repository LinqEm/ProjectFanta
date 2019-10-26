using System.Collections.Generic;
using ProjectFanta.Services.Interfaces;

namespace ProjectFanta 
{

    public interface ITwilioService 
    {
        void Broadcast(IEnumerable<ISubscriber> subscribers);

        void AddSubscriber(ISubscriber subscriber);
    }

}