using EmployeeManagementSystem.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagementSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<Salary> Salarys { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<EmployeeForManager> EmployeesForManagers { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
        public DbSet<TaskDetail> TaskDetails { get; set; }
    }
}
