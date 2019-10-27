using ProjectFanta.Interfaces;
using ProjectFanta.Services.Interfaces;
using Twilio.AspNet.Common;
using Twilio.TwiML;

namespace ProjectFanta.Services
{
    public class MessageHandler : IMessageHandler
    {
        private IBroadcaster broadcaster;
        private IGroupManager groupManager;

        public MessageHandler(ITwilioService twilioService, IGroupManager groupManager)
        {
            this.broadcaster = new Broadcaster(twilioService);
            this.groupManager = groupManager;
        }

        public MessagingResponse Handle(SmsRequest request)
        {
            var messagingResponse = new MessagingResponse();
            if (request.Body.ToUpper() == "UNSUBSCRIBE")
            {
                this.Unsubscribe(request.From);
                messagingResponse.Message("You have now been unsubscribed from any groups you previously subscribed to.");
            }
            else 
            {
                this.Broadcast(request);
                messagingResponse.Message("Broadcast Sent");
            }
            return messagingResponse;
        }

        private void Unsubscribe(string userPhoneNumber)
        {
            this.groupManager.UnsubscribeUser(userPhoneNumber);
        }

        private void Broadcast(SmsRequest request)
        {
            var message = request.Body;
            var adminNumber = request.From;

            this.broadcaster.Broadcast(message, this.groupManager.GetGroupByAdminPhoneNumber(adminNumber));
        }
    }
}