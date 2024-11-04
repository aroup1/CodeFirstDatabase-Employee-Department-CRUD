using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _4.CodeFirstDatabase_Employee_Department_Controller_Edit_Delete.Models
{
    //Jeisob table banabo seisob table er class Model er moddhe nite hobe
    //Import  using System.ComponentModel.DataAnnotations.Schema;
    //if i want to change DataBase Table name change I need   [Table("jekono name")]

    [Table("tblDepartment")] //This is optional.eita na dile class er name Table toiri korbe.
    public class Department
    {
        // Import     using System.ComponentModel.DataAnnotations;

        [Key]  //for primary key.na likhleo by default primary key bujhabe
        public int Id { get; set; }

        [Display(Name = "Department Name")]
        [StringLength(50)]
        [Required]
        //eigula jar upore deya hobe takei declare korbe
        public string Name { get; set; }
        public virtual List<Employee> Employees { get; set; } //eita diye Employee Table er link/reference bujhai

        //Ekta Department er moddhe onk gulo employee thakte pare tai ekhane List
        //virtual is a keyword for link other table
        //Employee is a DataType
        //Employees is a Propertises


        //jodi ekhane kono(Model it means class) change kora hoi tahole must be Web.Config DataBase er name change kore dite hobe

    }
}