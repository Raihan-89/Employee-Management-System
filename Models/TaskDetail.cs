namespace EmployeeManagementSystem.Models
{
    public class TaskDetail
    {

        public int Id { get; set; }
        public string EmployeeId { get; set; }
        public string Name { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; }
        public DateTime Deadline { get; set; }
        public string TaskStatus { get; set; }
    }
}
