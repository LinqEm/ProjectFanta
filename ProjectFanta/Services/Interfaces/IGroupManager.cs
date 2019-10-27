namespace ProjectFanta.Services.Interfaces
{
    public interface IGroupManager 
    {
        IGroup GetGroupByAdminPhoneNumber(string adminNumber);
        void AddSubscriberByKey(string key, IUser newUser);
        void RemoveGroupByAdmin(string adminNumber);
        // Creates a group and returns the auth key for that group
        string NewGroup(string adminNumber);

        void UnsubscribeUser(string userNumber);
    }
}