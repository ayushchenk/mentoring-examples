using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace FunctionAppExamples
{
    public class DeadLetterQueueTriggerFunction
    {
        [FunctionName("DeadLetterQueueTriggerFunction")]
        public void Run([ServiceBusTrigger("%DeadLetterQueueName%", Connection = "QueueConnectionString")] Contact contact, ILogger logger)
        {
            logger.LogInformation($"Contact: {contact.FirstName} {contact.LastName}");
        }
    }
}
