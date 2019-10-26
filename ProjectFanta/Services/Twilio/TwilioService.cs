using Microsoft.Extensions.Configuration;
using ProjectFanta.Services.Interfaces;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace ProjectFanta {

    class TwilioService : ITwilioService
    {
        private readonly string accountSid;
        private readonly string authToken;
        private string twilioPhoneNumber;

        public TwilioService(IConfiguration configuration) 
        {
            this.accountSid = configuration.GetValue<string>("TwilioSid");
            this.authToken = configuration.GetValue<string>("TwilioAuthToken");
            this.twilioPhoneNumber = configuration.GetValue<string>("TwilioPhoneNumber");
            TwilioClient.Init(accountSid, authToken);
        }

        public void SendMessage(IUser targetUser, string message)
        {
            MessageResource.Create(
                body: message,
                from: new Twilio.Types.PhoneNumber(this.twilioPhoneNumber),
                to: new Twilio.Types.PhoneNumber(targetUser.PhoneNumber)
            );
        }
    }

}