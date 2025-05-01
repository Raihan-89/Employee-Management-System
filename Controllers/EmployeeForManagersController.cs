using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Data;
using EmployeeManagementSystem.Models;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeForManagersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeForManagersController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var employeesForManager = await _context.Employees
            .Select(e => new EmployeeForManager
            {
                Id = e.Id,
                EmpNo = e.EmpNo,
                FullName = e.FullName,
                Position = e.Position,
                Department = e.Department,
                Email = e.Email,
                Country = e.Country,
                Address = e.Address,
                DateOfBirth = e.DateOfBirth,
                CreatedById = e.CreatedById,
                CreatedOn = e.CreatedOn,
                ModifiedById = e.ModifiedById,
                ModifiedOn = e.ModifiedOn
            })
            .ToListAsync();
            return View(employeesForManager);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employeeForManager = await _context.Employees
            .Where(e => e.Id == id)
            .Select(e => new EmployeeForManager
            {
                Id = e.Id,
                EmpNo = e.EmpNo,
                FullName = e.FullName,
                Position = e.Position,
                Department = e.Department,
                Email = e.Email,
                Country = e.Country,
                Address = e.Address,
                DateOfBirth = e.DateOfBirth,
                CreatedById = e.CreatedById,
                CreatedOn = e.CreatedOn,
                ModifiedById = e.ModifiedById,
                ModifiedOn = e.ModifiedOn
            })
            .FirstOrDefaultAsync();
            if (employeeForManager == null)
            {
                return NotFound();
            }

            return View(employeeForManager);
        }

        private bool EmployeeForManagerExists(int id)
        {
            return _context.EmployeesForManagers.Any(e => e.Id == id);
        }
    }
}
