using Microsoft.AspNetCore.Mvc;
using ProjectFanta.Interfaces;
using ProjectFanta.Services;
using ProjectFanta.Services.Interfaces;
using Twilio.AspNet.Common;
using Twilio.AspNet.Core;
using Twilio.TwiML;

namespace ProjectFanta.Controllers
{
    public class MessageController : TwilioController
    {
        private IMessageHandler messageHandler;

        
        public MessageController(ITwilioService twilioService, IGroupManager groupManager)
        {
            this.messageHandler = new MessageHandler(twilioService, groupManager);
        }

        [HttpPost]
        [Route("/api/message")]
        public TwiMLResult Index([FromForm] SmsRequest incomingMessage)
        {
            return TwiML(this.messageHandler.Handle(incomingMessage));
        }
    }
}