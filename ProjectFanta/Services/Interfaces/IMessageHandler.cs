using Twilio.AspNet.Common;
using Twilio.TwiML;

namespace ProjectFanta.Interfaces 
{

    public interface IMessageHandler 
    {
        MessagingResponse Handle(SmsRequest request);
    }

}