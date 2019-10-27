![](https://github.com/kanaikimi/project-fanta/blob/master/ProjectFanta/wwwroot/images/logo.png?raw=true)

# Project Fanta

Welcome to Project Fanta. Project Fanta is an instant and simple platform for anybody who wants to broadcast messages to subscribers using SMS! You can create a distribution group and have others sign up to your distribution group; any SMS messages you send to our number will be forwards to everyone who subscribed to your distribution group!

Project Fanta is a 24 hours project produced by Ethan Anderson, Sylvan Bowlder and Andy James from PebblePad at the HackTheMidlands 2019 event hosted by Birmingham University, and is Powered by .NET Core, and Twilio.


# Building and Running locally/for Development

First off, go ahead and install .NET Core 3.0 SDK. Visit https//dot.net/ for this. 

You'll then need to create and add your configuration for Twilio to the `appsettings.Development.json` file - create it next to the ProjectFanta.csproj if it doesn't not exist already.
You can find the values needed from your Twilio console at https://twilio.com/console. 


| Json Key          | Description                                                         |
|-------------------|---------------------------------------------------------------------|
| TwilioSid         | This is labelled Account SID under "Project Info" on the dashboard. |
| TwilioAuthToken   | This is right below your Account SID, click the textbox to show it. |
| TwilioPhoneNumber | This is at the top of the dashboard.                                |

Here's one we made earlier.

```
{
    "TwilioSid": "4BCD3FGH1JK1MN0PQRS7UVWXYZ",
    "TwilioAuthToken": "4BCD3FGH1JK1MN0PQRS7UVWXYZ",
    "TwilioPhoneNumber": "+441234567890"
}
```

Once you have these, `cd` to the `ProjectFanta` directory containing the `ProjectFanta.csproj`, and run `dotnet run --environment Development`.

You're now running, but we need one more step to complete the setup. You'll also need to setup the WebHook with Twilio.
For development, install NGrok at https://ngrok.com/ and in your command line execute `ngrok http 5000` and keep this running.
Find the URL similar to https://abc123.ngrok.io/ and take note of it. 

In your twilio panel, navigate to "All Products and Services" (the ... icon), then "# Phone Numbers" under the 'SUper Network' heading, click on your Twilio number, and under the "Messaging" section near the bottom set the "Configure With" field to "Webhooks, TwinML Bins, Functions, Studio, or Proxy". Right under this, set the dropdown field to "Webhook", the other dropdown to the right as "HTTP POST", and in the center textbox paste your NGrok URL adding `/api/messages` to the end, and Save! 

Navigate to your ngrok URL in your browser, and you're all set!

# Using it

1. Under the panel "Create a distribution group", enter and submit your phone number. Make sure it's right, you'll need to use this number to send messages to your subscribers!

2. Take the given distributon key and distribute and advertise it to your audience.

3. Under the panel "Subscribe to a distribution group", your audience can enter your distribution key, their phone number, and submit. They're now subscribed to your distribution group!

4. You will have received a message from your number. Reply back to this number with any message you want distributed to your subscribers!


# Unsubscribing

A user can unsubscribe at an time by replying to the phone number with "Unsubscribe", they will receive confirmation of this.


# Contribution guidelines

Make a Pull Request stating what you're changing and why it's valuable, and we'll take a look!