using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication2.EmployeeViewModels;
using WebApplication2.Models;
using WebApplication2.ViewModels;


namespace WebApplication2.Controllers
{
    
    public class EmployeeController : Controller
    {
        // GET: Test
        [Authorize]
        public ActionResult Index()
        {
            ViewModels.EmployeeListViewModel employeeListViewModel = new ViewModels.EmployeeListViewModel();
            employeeListViewModel.UserName = User.Identity.Name;

            employeeListViewModel.FooterData = new FooterViewModel();

            EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
            List<Employee> employees = empBal.GetEmployees();

            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.ToString("C");
                if (emp.Salary > 5000)
                {
                    empViewModel.SalaryColor = "yellow";
                }
                else
                {
                    empViewModel.SalaryColor = "green";
                }
                empViewModels.Add(empViewModel);
            }
            employeeListViewModel.Employees = empViewModels;
            employeeListViewModel.UserName = "Admin";

            employeeListViewModel.FooterData = new FooterViewModel();
            employeeListViewModel.FooterData.CompanyName = "云凯科技";
            employeeListViewModel.FooterData.Year = DateTime.Now.Year.ToString();
            return View("Index", employeeListViewModel);
        }
        public ActionResult AddNew()
        {
            return View("CreateEmployee", new CreateEmployeeViewModel());
        }

        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit)
            {
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                        empBal.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        CreateEmployeeViewModel vm = new CreateEmployeeViewModel();
                        vm.FirstName = e.FirstName;
                        vm.LastName = e.LastName;
                        if (e.Salary!=0)
                        {
                            vm.Salary = e.Salary.ToString();
                        }
                        else
                        {
                            vm.Salary = ModelState["Salary"].Value.AttemptedValue;
                        }
                        return View("CreateEmployee", vm); // Day 4 Change - Passing e here
                    }
                case "Cancel":
                    return RedirectToAction("Index");
            }
            return new EmptyResult();
        }
    }
}
