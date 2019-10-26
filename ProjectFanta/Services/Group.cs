using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFanta.Services.Interfaces;

namespace ProjectFanta.Services
{

    public class Group : IGroup
    {
        public Group(string adminNumber, string key)
        {
            this.Key = key;
            this.Admin = new User() { PhoneNumber = adminNumber };
            this.Subscribers = new List<IUser>();
        }

        public string Key { get; set; }
        public IList<IUser> Subscribers { get; set; }
        public IUser Admin { get; set; }
    }

}