using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace _4.CodeFirstDatabase_Employee_Department_Controller_Edit_Delete.Models
{
    //Jeisob table banabo seisob table er class Model er moddhe nite hobe
    //Import  using System.ComponentModel.DataAnnotations.Schema;
    //if i want to change DataBase Table name change I need   [Table("jekono name")]

    [Table("tblEmployee")] //This is optional.eita na dile class er name Table toiri korbe
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string City { get; set; }
        public int DepartmentId { get; set; }

        public virtual Department Departments { get; set; } //eita diye Department Table er link/reference bujhai

        //virtual is a keyword for link other table
        //Department is a DataType
        //Departments is a Propertises


        //jodi ekhane kono(Model it means class) change kora hoi tahole must be Web.Config DataBase er name change kore dite hobe

    }
}