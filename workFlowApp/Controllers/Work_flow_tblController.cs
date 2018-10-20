using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using workFlowApp;

namespace workFlowApp.Controllers
{
    public class Work_flow_tblController : Controller
    {
        private WorkFlowDBEntities db = new WorkFlowDBEntities();

        // GET: Work_flow_tbl
        public ActionResult Index()
        {
            return View(db.Work_flow_tbl.ToList());
        }

        // GET: Work_flow_tbl/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_flow_tbl work_flow_tbl = db.Work_flow_tbl.Find(id);
            if (work_flow_tbl == null)
            {
                return HttpNotFound();
            }
            return View(work_flow_tbl);
        }

        // GET: Work_flow_tbl/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Work_flow_tbl/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "work_flow_id,work_flow_name,work_flow_description,work_flow_status,work_flow_created_date,work_flow_owner,work_flow_created_user,entry_criteria")] Work_flow_tbl work_flow_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Work_flow_tbl.Add(work_flow_tbl);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(work_flow_tbl);
        }

        // GET: Work_flow_tbl/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_flow_tbl work_flow_tbl = db.Work_flow_tbl.Find(id);
            if (work_flow_tbl == null)
            {
                return HttpNotFound();
            }
            return View(work_flow_tbl);
        }

        // POST: Work_flow_tbl/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "work_flow_id,work_flow_name,work_flow_description,work_flow_status,work_flow_created_date,work_flow_owner,work_flow_created_user,entry_criteria")] Work_flow_tbl work_flow_tbl)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work_flow_tbl).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(work_flow_tbl);
        }

        // GET: Work_flow_tbl/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_flow_tbl work_flow_tbl = db.Work_flow_tbl.Find(id);
            if (work_flow_tbl == null)
            {
                return HttpNotFound();
            }
            return View(work_flow_tbl);
        }

        // POST: Work_flow_tbl/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Work_flow_tbl work_flow_tbl = db.Work_flow_tbl.Find(id);
            db.Work_flow_tbl.Remove(work_flow_tbl);
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
