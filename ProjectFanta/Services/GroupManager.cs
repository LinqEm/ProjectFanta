using System;
using System.Collections.Generic;
using System.Linq;
using ProjectFanta.Services.Interfaces;

namespace ProjectFanta.Services
{
    public class GroupManager : IGroupManager
    {

        private IList<IGroup> groups { get; set; }
        private IBroadcaster broadcaster;

        public GroupManager(ITwilioService twilioService)
        {
            this.groups = new List<IGroup>();
            this.broadcaster = new Broadcaster(twilioService);
        }

        private string GenerateKey()
        {
            var random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public IGroup GetGroupByAdminPhoneNumber(string adminNumber)
        {
            return this.groups.Where(g => g.Admin.PhoneNumber == adminNumber).FirstOrDefault();
        }

        public void AddSubscriberByKey(string key, IUser newUser)
        {
            var targetGroup = this.groups.Where(g => g.Key == key).FirstOrDefault();
            var updatedGroup = targetGroup;
            updatedGroup.Subscribers.Add(newUser);
            this.groups.Remove(targetGroup);
            this.groups.Add(updatedGroup);
            this.broadcaster.Broadcast("You have now subscribed to a broadcast group. Save this number to identify broadcast messages", new List<IUser>() { newUser });
        }

        public void RemoveGroupByAdmin(string adminNumber)
        {
            this.groups = this.groups.Where(g => g.Admin.PhoneNumber != adminNumber).ToList();
        }

        // Creates a group and returns the auth key for that group
        public string NewGroup(string adminNumber)
        {
            var key = GenerateKey();

            while (groups.Any(g => g.Key == key))
            {
                key = this.GenerateKey();
            }

            var newGroup = new Group(adminNumber, key);
            this.groups.Add(newGroup);

            this.broadcaster.Broadcast("You have now created a broadcast group. Send messages to this number to published a message to this group", new List<IUser>() { new User() { PhoneNumber = adminNumber } });
            return key;
        }

        public void UnsubscribeUser(string userNumber)
        {
            this.groups.Select(g => g.Subscribers.Where(u => u.PhoneNumber != userNumber));
        }
    }
}