using EmployeeRecords.Models;
using EmployeeRecords.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace EmployeeRecords.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmployee _employee;
        private readonly IDepartment _department;
        private readonly IEmployeeFiles employeeFiles;
        private readonly IWebHostEnvironment appEnvironment;
        public HomeController(IEmployee _employee,IDepartment _department,
            IEmployeeFiles employeeFiles,
            IWebHostEnvironment appEnvironment)
        {
            this._employee = _employee;
            this._department = _department;
            this.employeeFiles = employeeFiles;
            this.appEnvironment = appEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                TempData["AllDept"] = await _department.GetAllDept();
                return View(await _employee.GetAllEmployees());
            }
            catch { 
                return View("ErrorPages","ErrorServer");
            }
        }
        public async Task<IActionResult> Create(Employee employee, IFormFile file)
        {

       
            var User = await _employee.CreateEmployee(employee);
            if (User != null)
            {
                await employeeFiles.CreateImage(file, User.ID);
                return RedirectToAction("Index");
            }
              

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Employee Employee,IFormFile file)
        {
            var User = await _employee.UpdateEmployee(id, Employee);
            if (User != null) {
                if (file != null)
                {
                    await employeeFiles.EditImage(file, id);
                }
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Delete(int id)
        {
           var User = await _employee.DeleteEmployee(id);
            if(User!=null)
            return RedirectToAction("Index");

           return View();
        }
        public async Task<IActionResult> Search(string value)
        {
            var User = await _employee.FindEmployee(value);
            if (User != null)
                return Json(User);

            return Json(null);
        }
        public async Task<IActionResult> GetEmployee(int ID)
        {
            var User = await _employee.GetEmployee(ID);
            if (User != null)
                return Json(User);

            return Json(null);
        }
        public IActionResult ErrorPages()
        {
            return PartialView();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
