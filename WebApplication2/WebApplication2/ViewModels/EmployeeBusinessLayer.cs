using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication2.Data_Access_Layer;

namespace WebApplication2.Models
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees()
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.Employees.ToList();
        }
        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }
        public UserStatus GetUserValidity(UserDetails u)

        {

            if (u.UserName == "Admin" && u.Password == "123")

            {

                return UserStatus.AuthenticatedAdmin;

            }

            else if (u.UserName == "User" && u.Password == "123")

            {

                return UserStatus.AuthentucatedUser;

            }

            else

            {

                return UserStatus.NonAuthenticatedUser;

            }

        }

    }
}

