using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using workFlowApp.Models;

namespace workFlowApp.Controllers
{
    public class LoginController : Controller
    {
        private WorkFlowDBEntities db = new WorkFlowDBEntities();

        // GET: Login
        public ActionResult Index()
        {

            return  RedirectToAction("Create");
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "Email,Password")] Login login)
        {
            try
            {
                if (ModelState.IsValid) {
                    AuthValidator authValidator = new AuthValidator();
                    tbl_empoyee tbl_Empoyee = authValidator.IsvalidUser(login);

                    Session["Email"] = tbl_Empoyee.emp_name;
                    Session["Role"] = tbl_Empoyee.emp_role;
                    Session["Name"] = tbl_Empoyee.emp_name;

                    return RedirectToAction("Home/Index");
                }
                else
                {
                    return View(login);
                }

            }
            catch (Exception exception)
            {
                ViewBag.errormeaasge = exception.Message;
                return View();
            }
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
