using _4.CodeFirstDatabase_Employee_Department_Controller_Edit_Delete.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _4.CodeFirstDatabase_Employee_Department_Controller_Edit_Delete.Controllers
{
    public class DepartmentController : Controller
    {
        //Import  using _4.CodeFirstDatabase_Employee_Department_Controller_Edit_Delete.Models;

        EMSDataContext db = new EMSDataContext();

        // GET: Department
        public ActionResult Index()  //Index er kaj holo Data dekhano
        {
            return View(db.Departments.ToList());   //ActionResult dataType allways return type View hobe

            //Add View Data context class er jonno first of all project Build kore nite hobe
        }

        [HttpGet]  //HttpGet means dekhar jonno.ekhane konokicu na likhleo default vabe HttpGet bujhai
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]  //HttpPost means submit button er jonno 
        public ActionResult Create(Department dept)
        {
            if (ModelState.IsValid)    //IsValid means kono error nai(validation er jonno)
            {
                db.Departments.Add(dept);
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }

        public ActionResult Details(int id)
        {
            var data = db.Departments.Where(d => d.Id == id).FirstOrDefault();
            return View(data);
        }

        [HttpGet] //for only data show
        public ActionResult Edit(int id)
        {
            //var dept = db.Departments.Where(d => d.Id == id).FirstOrDefault();
            // or
            Department dept = db.Departments.Find(id);

            if (dept == null)
            {
                return HttpNotFound();
            }

            return View(dept);
        }

        [HttpPost] //when click submit button
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department dept)
        {

            if (ModelState.IsValid)
            {
                //Import   using System.Data.Entity;

                db.Entry(dept).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dept);
        }

        [HttpGet] //for only data show
        public ActionResult Delete(int id)
        {
            //Department dept = db.Departments.Find(id);
            // or
            var dept = db.Departments.Where(d => d.Id == id).FirstOrDefault();

            if (dept == null)
            {
                return HttpNotFound();
            }

            return View(dept);
        }

        [HttpPost, ActionName("Delete")] //ActionName("Delete") means Delete k bujhai
        [ValidateAntiForgeryToken]  //optional.dileo hobe,na dileo hobe
        public ActionResult DeleteData(int id)  //[HttpGet] Delete er poriborte [HttpPost] ekhane jekono name hote pare.Example  DeleteData.Delete er jonno [HttpGet] er moddhe jei name thakbe [HttpPost] er moddhe alada name dite hobe
        {

            Department dept = db.Departments.Find(id);
            db.Departments.Remove(dept);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}