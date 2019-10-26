using System;
using System.Collections.Generic;

namespace ProjectFanta.Services.Interfaces {

    public interface ISubscriberRepo
    {
        IEnumerable<ISubscriber> GetByKey(string key);
        void Create(ISubscriber owner);
    }

}