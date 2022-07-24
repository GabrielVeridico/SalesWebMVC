using Microsoft.AspNetCore.Mvc;
using SalesWebMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMVC.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            var departmentList = new List<Department>();
            departmentList.Add(new Department { Id = 1, Name = "Eletronics" });
            departmentList.Add(new Department { Id = 2, Name = "Fashion" });

            return View(departmentList);
        }
    }
}
