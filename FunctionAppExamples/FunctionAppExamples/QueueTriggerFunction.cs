using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace FunctionAppExamples
{
    public class QueueTriggerFunction
    {
        [FunctionName("QueueTriggerFunction")]
        public void Run([ServiceBusTrigger("%QueueName%", Connection = "QueueConnectionString")] SampleModel queueItem, ILogger logger)
        {
            if (queueItem.Throw) throw new InvalidOperationException(queueItem.Message);
            logger.LogInformation("Message processed");
        }
    }
}
