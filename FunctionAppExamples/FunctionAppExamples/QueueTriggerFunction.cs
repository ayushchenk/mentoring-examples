using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Xrm.Sdk;
using System;

namespace FunctionAppExamples
{
    public class QueueTriggerFunction
    {
        [FunctionName("QueueTriggerFunction")]
        public void Run([ServiceBusTrigger("%QueueName%", Connection = "QueueConnectionString")] Contact contact, ILogger logger)
        {
            if (contact.Throw) throw new InvalidOperationException(contact.FirstName);

            var clientId = Environment.GetEnvironmentVariable("AppUserClientId");
            var clientSecret = Environment.GetEnvironmentVariable("AppUserClientSecret");
            var environmentUrl = Environment.GetEnvironmentVariable("EnvironmentUrl");

            using var serviceClient = new ServiceClient($"AuthType=ClientSecret;Url={environmentUrl};ClientId={clientId};ClientSecret={clientSecret}", logger);
            
            serviceClient.Create(new Entity("contact")
            {
                ["firstname"] = contact.FirstName,
                ["lastname"] = contact.LastName
            });

            logger.LogInformation($"Contact {contact.FirstName} {contact.LastName} created");
        }
    }
}
