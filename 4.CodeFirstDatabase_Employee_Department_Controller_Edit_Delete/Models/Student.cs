using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _4.CodeFirstDatabase_Employee_Department_Controller_Edit_Delete.Models
{
    //Import    using System.ComponentModel.DataAnnotations.Schema;
    //if i want to change DataBase Table name. I need write  [Table("jekono name")]

    [Table("tblStudenta")]

    public class Student
    {
        // Import     using System.ComponentModel.DataAnnotations;

        [Key]
        public int Id { get; set; }
        [Display(Name = "Student Name")]
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [Display(Name = "Email Address")]
        [StringLength(40)]
        [EmailAddress]
        public string Email { get; set; }

        //jodi ekhane kono(Model it means class) change kora hoi tahole must be Web.Config DataBase er name change kore dite hobe

    }
}