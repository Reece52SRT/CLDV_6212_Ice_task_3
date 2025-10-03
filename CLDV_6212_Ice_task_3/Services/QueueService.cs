using Azure.Storage.Queues;
using System.Text.Json;
using System.Threading.Tasks;
using CLDV_6212_Ice_task_3.Models;

namespace CLDV_6212_Ice_task_3.Services
{
    public class QueueService
    {
        private readonly QueueClient _queueClient;

        public QueueService(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("StorageAccount");
            _queueClient = new QueueClient(connectionString, "personqueue");

            // Create queue if not exists
            _queueClient.CreateIfNotExists();
        }

        public async Task EnqueuePersonAsync(PersonMessage message)
        {
            var payload = JsonSerializer.Serialize(message);
            await _queueClient.SendMessageAsync(payload);
        }
    }
}
