using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace FunctionAppExamples
{
    public class DeadLetterQueueTriggerFunction
    {
        [FunctionName("DeadLetterQueueTriggerFunction")]
        public void Run([ServiceBusTrigger("%DeadLetterQueueName%", Connection = "QueueConnectionString")] SampleModel queueItem, ILogger logger)
        {
            logger.LogInformation($"Message: {queueItem.Message}");
        }
    }
}
