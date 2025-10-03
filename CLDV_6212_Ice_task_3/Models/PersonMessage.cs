namespace CLDV_6212_Ice_task_3.Models
{
    public class PersonMessage
    {
        public string PartitionKey { get; set; } = "people";
        public string RowKey { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
}
