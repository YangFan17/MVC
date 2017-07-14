using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.ViewModels;

namespace WebApplication2.EmployeeViewModels
{
    public class EmployeeListViewModel
    {
        public List<EmployeeViewModel> Employees { get; set; }  
        public string UserName { get; set; }
        public FooterViewModel FooterData { get; set; }
    }
}