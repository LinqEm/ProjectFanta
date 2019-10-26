using System.Collections.Generic;
using System.Linq;
using ProjectFanta.Services.Interfaces;

namespace ProjectFanta.Services {

    class SubscriberRepo : ISubscriberRepo
    {
        private List<ISubscriber> Subscribers { get; set; }

        public void Create(ISubscriber owner)
        {
            this.Subscribers.Add(owner);
        }

        public IEnumerable<ISubscriber> GetByKey(string key)
        {
            return this.Subscribers.Where(x => x.AuthKey == key);
        }
    }

}