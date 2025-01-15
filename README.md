local.settings.json

```json
{
  "IsEncrypted": false,
  "Values": {
    "AzureWebJobsStorage": "UseDevelopmentStorage=true",
    "FUNCTIONS_INPROC_NET8_ENABLED": "1",
    "FUNCTIONS_WORKER_RUNTIME": "dotnet",
    "QueueConnectionString": "<connection string value WIHTOUT EntityPath>",
    "QueueName": "mentoring-queue",
    "DeadLetterQueueName": "mentoring-queue/$deadletterqueue"
  }
}
```
