using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _1._3.Models;

namespace _1._3.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeDataAccessLayer objEmployee = new EmployeeDataAccessLayer();

        public IActionResult Index()
        {
            List<Employee> lstEmployee = new List<Employee>();
            lstEmployee = objEmployee.GetAllEmployees().ToList();

            return View(lstEmployee);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Employee Employee)
        {
            if (ModelState.IsValid)
            {
                objEmployee.AddEmployee(Employee);
                return RedirectToAction("Index");
            }
            return View(Employee);
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee Employee = objEmployee.GetEmployeeData(id);

            if (Employee == null)
            {
                return NotFound();
            }
            return View(Employee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind]Employee Employee)
        {
            if (id != Employee.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                objEmployee.UpdateEmployee(Employee);
                return RedirectToAction("Index");
            }
            return View(Employee);
        }

        [HttpGet]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee Employee = objEmployee.GetEmployeeData(id);

            if (Employee == null)
            {
                return NotFound();
            }
            return View(Employee);
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee Employee = objEmployee.GetEmployeeData(id);

            if (Employee == null)
            {
                return NotFound();
            }
            return View(Employee);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            objEmployee.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}