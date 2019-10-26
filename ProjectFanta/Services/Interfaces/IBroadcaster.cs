using System.Collections.Generic;
using ProjectFanta.Services.Interfaces;

namespace ProjectFanta.Services.Interfaces 
{

    public interface IBroadcaster 
    {
        void Broadcast(string broadcastMessage, IGroup group);
    }

}