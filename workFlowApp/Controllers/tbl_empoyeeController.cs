using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using workFlowApp;
using workFlowApp.Models;

namespace workFlowApp.Controllers
{
    public class tbl_empoyeeController : Controller
    {
        private WorkFlowDBEntities db = new WorkFlowDBEntities();

        // GET: tbl_empoyee
        public ActionResult Index()
        {
            
            if (AuthValidator.IsAdministrator(Session["Email"].ToString(), Session["Role"].ToString()))
            {
                var tbl_empoyee = db.tbl_empoyee.Include(t => t.tbl_role);
                return View(tbl_empoyee.ToList());
            }
            else
            {
                return RedirectToAction("index","Login");
            }
        }

        // GET: tbl_empoyee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_empoyee tbl_empoyee = db.tbl_empoyee.Find(id);
            if (tbl_empoyee == null)
            {
                return HttpNotFound();
            }
            return View(tbl_empoyee);
        }

        // GET: tbl_empoyee/Create
        public ActionResult Create()
        {
            ViewBag.emp_role = new SelectList(db.tbl_role, "role_id", "role_name");
            return View();
        }

        // POST: tbl_empoyee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "emp_id,emp_name,emp_role,status,nic,email,password,created_date")] tbl_empoyee tbl_empoyee)
        {
            if (ModelState.IsValid)
            {
                db.tbl_empoyee.Add(tbl_empoyee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.emp_role = new SelectList(db.tbl_role, "role_id", "role_name", tbl_empoyee.emp_role);
            return View(tbl_empoyee);
        }

        // GET: tbl_empoyee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_empoyee tbl_empoyee = db.tbl_empoyee.Find(id);
            if (tbl_empoyee == null)
            {
                return HttpNotFound();
            }
            ViewBag.emp_role = new SelectList(db.tbl_role, "role_id", "role_name", tbl_empoyee.emp_role);
            return View(tbl_empoyee);
        }

        // POST: tbl_empoyee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "emp_id,emp_name,emp_role,status,nic,email,password,created_date")] tbl_empoyee tbl_empoyee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_empoyee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.emp_role = new SelectList(db.tbl_role, "role_id", "role_name", tbl_empoyee.emp_role);
            return View(tbl_empoyee);
        }

        // GET: tbl_empoyee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_empoyee tbl_empoyee = db.tbl_empoyee.Find(id);
            if (tbl_empoyee == null)
            {
                return HttpNotFound();
            }
            return View(tbl_empoyee);
        }

        // POST: tbl_empoyee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_empoyee tbl_empoyee = db.tbl_empoyee.Find(id);
            db.tbl_empoyee.Remove(tbl_empoyee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
