using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure;
using Azure.Data.Tables;

namespace FunctionApp_Ice_Task.Models
{
    class PersonEntity : ITableEntity
    {
        public string PartitionKey { get; set; } = "people";
        public string RowKey { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public int Age { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
