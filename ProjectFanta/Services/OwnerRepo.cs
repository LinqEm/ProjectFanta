using System.Collections.Generic;
using System.Linq;
using ProjectFanta.Services.Interfaces;

namespace ProjectFanta.Services {

    class OwnerRepo : IOwnerRepo
    {
        private List<IOwner> Owners { get; set; }

        public void Create(IOwner owner)
        {
            this.Owners.Add(owner);
        }

        public IOwner GetByKey(string key)
        {
            return this.Owners.Where(x => x.AuthKey == key).FirstOrDefault();
        }
    }

}