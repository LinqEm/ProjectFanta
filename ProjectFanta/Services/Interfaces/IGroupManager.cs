namespace ProjectFanta.Services.Interfaces
{
    public interface IGroupManager 
    {
        IGroup GetGroupByAdmin(IUser target);
        void AddSubscriberByKey(string key);
        void RemoveGroup();        
        // Creates a group and returns the auth key for that group
        string NewGroup(string adminNumber);
    }
}