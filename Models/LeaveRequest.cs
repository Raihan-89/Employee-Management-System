namespace EmployeeManagementSystem.Models
{
    public class LeaveRequest
    {
        public int Id { get; set; }
        public string EmployeeName { get; set; }
        public int NoOfDays { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public string LeaveTypeName { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
