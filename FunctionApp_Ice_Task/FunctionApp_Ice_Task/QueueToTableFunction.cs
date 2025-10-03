using System;
using Azure.Storage.Queues.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Azure.Data.Tables;
using FunctionApp_Ice_Task.Models;
using System.Text.Json;


namespace FunctionApp_Ice_Task;

public class QueueToTableFunction
{



    private readonly ILogger<QueueToTableFunction> _logger;
    public QueueToTableFunction(ILoggerFactory lf) => _logger = lf.CreateLogger<QueueToTableFunction>();

    [Function("QueueToTableFunction")]
    public async Task Run(
        [QueueTrigger("personqueue", Connection = "AzureWebJobsStorage")] string message)
    {
        _logger.LogInformation("Queue message: {msg}", message);

        var person = JsonSerializer.Deserialize<PersonEntity>(message);
        if (person is null) { _logger.LogError("Bad payload"); return; }

        var tableClient = new TableClient(Environment.GetEnvironmentVariable("AzureWebJobsStorage")!, "Persons");
        await tableClient.CreateIfNotExistsAsync();
        await tableClient.AddEntityAsync(person);
        _logger.LogInformation("Inserted {name}", person.RowKey);
    }
}