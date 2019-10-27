using Microsoft.AspNetCore.Mvc;
using ProjectFanta.Services;
using ProjectFanta.Services.Interfaces;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace ProjectFanta.Controllers
{
    public class MessageController : TwilioController
    {

        private IGroupManager groupManager;
        private Broadcaster broadcaster;

        
        public MessageController(ITwilioService twilioService, IGroupManager groupManager)
        {
            this.groupManager = groupManager;
            this.broadcaster = new Broadcaster(twilioService);

            var key = this.groupManager.NewGroup("+447713878886");
            this.groupManager.AddSubscriberByKey(key, new User() { PhoneNumber = "+447713878886"});
        }

        [HttpPost]
        public TwiMLResult Index(SmsRequest incomingMessage)
        {
            var message = incomingMessage.Body;
            var adminNumber = incomingMessage.From;

            this.broadcaster.Broadcast(message, this.groupManager.GetGroupByAdminPhoneNumber(adminNumber));

            var messagingResponse = new MessagingResponse();
            messagingResponse.Message("Broadcast Sent");

            return TwiML(messagingResponse);
        }
    }
}