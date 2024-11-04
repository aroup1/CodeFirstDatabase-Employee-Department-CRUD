using _4.CodeFirstDatabase_Employee_Department_Controller_Edit_Delete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4.CodeFirstDatabase_Employee_Department_Controller_Edit_Delete.Controllers
{
    public class StudentController : Controller
    {
        //Import    using _3.CodeFirstDataBase_Employee_Department.Models;
        DatabaseContext db = new DatabaseContext();
        // GET: Student
        public ActionResult Index()
        {
            var data = db.Students.ToList();
            return View(data);  //ActionResult dataType allways return type View hobe

            //Add View Data context class er jonno first of all project Build kore nite hobe
        }
        [HttpGet]  /* HttpGet means dekhar jonno.ekhane konokicu na likhleo default vabe HttpGet bujhai */
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]  /* HttpPost means submit er jonno */
        public ActionResult Create(FormCollection frc)
        {
            //foreach (var item in frc.AllKeys)
            //{
            //    Response.Write("Key:" + item);
            //    Response.Write("Value:" +frc[ item]);
            //    Response.Write("<br/>");
            //}

            //return View();

            //================================================

            Student std = new Student();

            std.Name = frc["Name"];     // frc["this is field name(table er field name)"];
            std.Email = frc["Email"];

            db.Students.Add(std);
            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}