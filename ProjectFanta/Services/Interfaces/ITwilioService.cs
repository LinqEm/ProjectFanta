namespace ProjectFanta.Services.Interfaces
{
    public interface ITwilioService 
    {
       void SendMessage(IUser targetUser);
    }
}