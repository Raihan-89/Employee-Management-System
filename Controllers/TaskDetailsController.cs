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
    public class TaskDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TaskDetails.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskDetail = await _context.TaskDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskDetail == null)
            {
                return NotFound();
            }

            return View(taskDetail);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create( TaskDetail taskDetail)
        {
            //if (ModelState.IsValid)
            //{
            //}
            taskDetail.TaskStatus = "Pending";
            _context.Add(taskDetail);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //return View(taskDetail);
        }

        public async Task<IActionResult> Assign(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskDetail = await _context.TaskDetails.FindAsync(id);
            if (taskDetail == null)
            {
                return NotFound();
            }
            return View(taskDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Assign(int id, TaskDetail taskDetail)
        {
            if (id != taskDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    taskDetail.TaskStatus = "Assigned";
                    _context.Update(taskDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskDetailExists(taskDetail.Id))
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
            return View(taskDetail);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskDetail = await _context.TaskDetails.FindAsync(id);
            if (taskDetail == null)
            {
                return NotFound();
            }
            return View(taskDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, TaskDetail taskDetail)
        {
            if (id != taskDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if(taskDetail.TaskStatus != "Assigned")
                    {
                        taskDetail.TaskStatus = "Pending";
                    }
                    _context.Update(taskDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskDetailExists(taskDetail.Id))
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
            return View(taskDetail);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskDetail = await _context.TaskDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskDetail == null)
            {
                return NotFound();
            }

            return View(taskDetail);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskDetail = await _context.TaskDetails.FindAsync(id);
            if (taskDetail != null)
            {
                _context.TaskDetails.Remove(taskDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskDetailExists(int id)
        {
            return _context.TaskDetails.Any(e => e.Id == id);
        }
    }
}
