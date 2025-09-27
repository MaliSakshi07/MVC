using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Student_App.Models;

namespace Student_App.Controllers
{
    public class HomeController : Controller
    {
        StudentContext db = new StudentContext();
        public ActionResult Index()
        {
            var data = db.students.ToList();
            return View(data);
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Student s)
        {
           if(ModelState.IsValid == true)
            {
                db.students.Add(s);
                int a = db.SaveChanges();

                if (a > 0)
                {
                    ViewBag.InsertMessage = "<script>alert('Data Inserted Successfully !!!')</Script>";
                    //TempData["InsertMessage"] = "<script>alert('Data Inserted Successfully !!!')</Script>";
                    //return RedirectToAction("Index");
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.InsertMessage = "<script>alert('Data Not Inserted !!!')</script>";
                }
            }
            return View();
        }

        public ActionResult Edit(int id)
        {
            var row = db.students.Where(model => model.Id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(Student s)
        {
            db.Entry(s).State = EntityState.Modified;
            int a = db.SaveChanges();
            if(a > 0)
            {
                ViewBag.UpdateMessage = "<script>alert('Data Updated Successfully !!!')</Script>";
                ModelState.Clear();

            }
            else
            {
                ViewBag.UpdateMessage = "<script>alert('Data Not Updated !!!')</script>";
            }
            return View();
        }

        public ActionResult Details(int id)
        {
            var StudDetails = db.students.Where(model => model.Id == id).FirstOrDefault();
            return View(StudDetails);
        }

        public ActionResult Delete(int id)
        {
            var StudIdRow = db.students.Where(model => model.Id == id).FirstOrDefault();
            return View(StudIdRow);
        }

        [HttpPost]
        public ActionResult Delete(Student s)
        {
            db.Entry(s).State = EntityState.Deleted;
            int a = db.SaveChanges();
            if (a > 0)
            {
                ViewBag.DeletedMessage= "<script>alert('Data Deleted Successfully !!!')</Script>";
            }
            else
            {
                ViewBag.DeletedMessage = "<script>alert('Data Not Deleted !!!')</Script>";
            }
            return RedirectToAction("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}