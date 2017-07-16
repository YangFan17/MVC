using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.ViewModels;

namespace WebApplication2.EmployeeViewModels
{
    public class EmployeeListViewModel : BaseViewModel
    {
        public List<EmployeeViewModel> Employees { get; set; }
    }
}