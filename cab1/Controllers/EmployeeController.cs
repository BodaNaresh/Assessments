using CabManagementSysytem.Data;
using CabManagementSysytem.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CabManagementSysytem.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _context;
       
        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var emp = _context.Employees.ToList();
            return View(emp);
        }
        public IActionResult Details(int id)
        {
            var employee = _context.Employees.FirstOrDefault(m => m.Id == id);
            return View(employee);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateEmp(Employee employee)
        {
            _context.Add(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var employee = _context.Employees.Find(id);
            return View(employee);
        }
        public IActionResult DeleteEmp(int id)
        {
            var employee = _context.Employees.FirstOrDefault(m => m.Id == id);
            _context.Employees.Remove(employee);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var employee = _context.Employees.FirstOrDefault(m => m.Id == id);
            return View(employee);
        }

        public IActionResult EditEmp(Employee employee)
        {
            _context.Update(employee);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
