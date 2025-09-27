using CRUD_App.Models;
using CRUD_App.QueryFunction;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_App.Controllers
{
    public class CompanyController : Controller
    {
        // GET: Company
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(FormCollection collection)
        {
            CompanyModel companyModel = new CompanyModel();
            companyModel.Comp_Name = Convert.ToString(collection["Comp_Name"]);
            if (!string.IsNullOrWhiteSpace(collection["Stength"]))
            {
                companyModel.Stength = Convert.ToInt32(collection["Stength"]);
            }
            companyModel.Remarks = Convert.ToString(collection["Remarks"]);

            if (string.IsNullOrWhiteSpace(companyModel.Comp_Name))
            {
                ModelState.AddModelError("Comp_Name", "Please Enter Company");
            }
            CompanyQuery company = new CompanyQuery();

            if (ModelState.IsValid)
            {
                int Res = company.InsertData(companyModel);

                if (Res > 0)
                {
                    TempData["Message"] = "Data Inserted Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(companyModel);
                }
            }

            return View(companyModel);
        }

        public ActionResult Edit(int Id = 0)
        {
            CompanyModel model = FillcompanyDetilas(Id);

            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(FormCollection collection)
        {
            CompanyModel companyModel = new CompanyModel();
            companyModel.Comp_Name = Convert.ToString(collection["Comp_Name"]);
            companyModel.Comp_No = Convert.ToInt32(collection["Comp_No"]);
            if (!string.IsNullOrWhiteSpace(collection["Stength"]))
            {
                companyModel.Stength = Convert.ToInt32(collection["Stength"]);
            }
            companyModel.Remarks = Convert.ToString(collection["Remarks"]);

            if (string.IsNullOrWhiteSpace(companyModel.Comp_Name))
            {
                ModelState.AddModelError("Comp_Name", "Please Enter Company");
            }
            CompanyQuery company = new CompanyQuery();
            if (ModelState.IsValid)
            {
                int Res = company.UpdateData(companyModel);
                if (Res > 0)
                {
                    TempData["Message"] = "Data Update Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(companyModel);
                }
            }
            return View(companyModel);
        }
        public ActionResult Delete(int Id = 0)
        {
            CompanyModel model = FillcompanyDetilas(Id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(FormCollection collection)
        {
            int CompNo = Convert.ToInt32(collection["Comp_No"]);
            CompanyQuery company = new CompanyQuery();
            int Res = company.DeleteData(CompNo);

            if (Res > 0)
            {
                TempData["Message"] = "Data Delete Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                CompanyModel companyModel = FillcompanyDetilas(CompNo);
                return View(companyModel);
            }
        }
        public ActionResult Details(int? Id = 0)
        {
            return View();
        }

        public static CompanyModel FillcompanyDetilas(int Id)
        {
            CompanyModel model = new CompanyModel();

            CompanyQuery company = new CompanyQuery();
            DataTable dt = company.GetCompanyDetails(Id);

            if (dt.Rows.Count > 0)
            {
                model.Comp_No = Convert.ToInt32(dt.Rows[0]["COmp_No"]);
                model.Comp_Name = Convert.ToString(dt.Rows[0]["Comp_Name"]);
                model.Stength = Convert.ToInt32(dt.Rows[0]["Strength"]);
                model.Remarks = Convert.ToString(dt.Rows[0]["Remarks"]);
            }
            return model;
        }
    }
}