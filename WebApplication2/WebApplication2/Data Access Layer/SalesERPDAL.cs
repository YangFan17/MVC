using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
//定义映射关系
using WebApplication2.Models;


namespace WebApplication2.Data_Access_Layer
{
    public class SalesERPDAL : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().ToTable("TblEmployee");
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Employee> Employees { get; set; }
    }
}