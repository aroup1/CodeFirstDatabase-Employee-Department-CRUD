using _4.CodeFirstDatabase_Employee_Department_Controller_Edit_Delete.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4.CodeFirstDatabase_Employee_Department_Controller_Edit_Delete.Controllers
{
    public class EmployeeController : Controller
    {
        //Import  using _4.Employee_Department_Controller_Edit_Delete.Models;

        EMSDataContext db = new EMSDataContext();

        // GET: Employee
        public ActionResult Index()  //Index er kaj holo Data dekhano
        {
            return View(db.Employees.ToList());   //ActionResult dataType allways return type View hobe

            //Add View Data context class er jonno first of all project Build kore nite hobe
        }

        [HttpGet]  //HttpGet means dekhar jonno.ekhane konokicu na likhleo default vabe HttpGet bujhai
        public ActionResult Create()
        {
            //ViewBag.tblEmployee table er Foreign Key = new SelectList(List,ValueField,TextField);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");

            return View();
        }

        [HttpPost] //HttpPost means submit button er jonno 
        public ActionResult Create(Employee emp)
        {
            if (ModelState.IsValid)    //IsValid means kono error nai(validation er jonno)
            {
                db.Employees.Add(emp);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            //ViewBag.tblEmployee table er Foreign Key = new SelectList(List,ValueField,TextField);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");

            return View();
        }

        public ActionResult Details(int id)
        {
            var data = db.Employees.Where(d => d.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpGet] //for only data show
        public ActionResult Edit(int id)
        {
            var emp = db.Employees.Where(d => d.Id == id).FirstOrDefault();
            // or
            //Employee emp = db.Employees.Find(id);

            if (emp == null)
            {
                return HttpNotFound();
            }

            //ViewBag.tblEmployee table er Foreign Key = new SelectList(List,ValueField,TextField);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");

            return View(emp);
        }

        [HttpPost] //when click submit button
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {

            if (ModelState.IsValid)
            {
                //Import   using System.Data.Entity;

                db.Entry(emp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp);
        }

        [HttpGet] //for only data show
        public ActionResult Delete(int id)
        {
            //Employee emp = db.Employees.Find(id);
            // or
            var emp = db.Employees.Where(d => d.Id == id).FirstOrDefault();

            if (emp == null)
            {
                return HttpNotFound();
            }
            return View(emp);
        }

        [HttpPost, ActionName("Delete")] //when click submit button.ActionName("Delete") means Delete k bujhai
        [ValidateAntiForgeryToken]
        public ActionResult DeleteData(int id)  //[HttpGet] Delete er poriborte [HttpPost] ekhane jekono name hote pare.Example  DeleteData.Delete er jonno [HttpGet] er moddhe jei name thakbe [HttpPost] er moddhe alada name dite hobe
        {

            Employee emp = db.Employees.Find(id);
            db.Employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}