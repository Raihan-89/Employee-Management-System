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
    public class EmployeesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var employee = await _context.Employees
           .Select(e => new Employee
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
            return View(employee);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = await _context.Employees
            .Where(e => e.Id == id)
            .Select(e => new Employee
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
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Employee employee)
        {
            employee.CreatedById = "Raihan";
            employee.CreatedOn = DateTime.Now;
            if (ModelState.IsValid)
            {
                _context.Add(employee);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees
            .Where(e => e.Id == id)
            .Select(e => new Employee
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
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Employee employee)
        {
            
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeExists(employee.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var employee = await _context.Employees
            .Where(e => e.Id == id)
            .Select(e => new Employee
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
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var employee = await _context.Employees
            .Where(e => e.Id == id)
            .Select(e => new Employee
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
            if (employee != null)
            {
                _context.Employees.Remove(employee);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeExists(int id)
        {
            return _context.Employees.Any(e => e.Id == id);
        }
    }
}
