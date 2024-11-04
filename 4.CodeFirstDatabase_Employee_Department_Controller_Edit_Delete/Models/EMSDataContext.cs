using System;
using System.Collections.Generic;
using System.Data.Entity;   // Install EntityFramework
using System.Linq;
using System.Web;

namespace _4.CodeFirstDatabase_Employee_Department_Controller_Edit_Delete.Models
{
    //Import   using System.Data.Entity;    (:) colon means inheritance
    public class EMSDataContext : DbContext  //Import  using System.Data.Entity;  for DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}