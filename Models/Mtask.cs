namespace ManagementDesTaches.Models
{
    public class Mtask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public DateTime DueDate { get; set; } = DateTime.Now;
        public  string status { get; set; }
    }
public enum Status
{
    Success,
    InProgress,
    Completed
}
}
