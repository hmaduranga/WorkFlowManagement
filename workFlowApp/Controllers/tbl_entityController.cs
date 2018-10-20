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
    public class tbl_entityController : Controller
    {
        private WorkFlowDBEntities db = new WorkFlowDBEntities();

        // GET: tbl_entity
        public ActionResult Index()
        {
            var tbl_entity = db.tbl_entity.Include(t => t.tbl_empoyee).Include(t => t.Work_flow_tbl);
            return View(tbl_entity.ToList());
        }

        // GET: tbl_entity/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_entity tbl_entity = db.tbl_entity.Find(id);
            if (tbl_entity == null)
            {
                return HttpNotFound();
            }
            return View(tbl_entity);
        }

        // GET: tbl_entity/Create
        public ActionResult Create()
        {
            ViewBag.entity_owner = new SelectList(db.tbl_empoyee, "emp_id", "emp_name");
            ViewBag.workflow_id = new SelectList(db.Work_flow_tbl, "work_flow_id", "work_flow_name");
            return View();
        }

        // POST: tbl_entity/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "entity_id,entity_name,action_name,action_description,entry_criteria,exit_criteria,entity_owner,entity_status,change_status,workflow_id")] tbl_entity tbl_entity)
        {
            if (ModelState.IsValid)
            {
                db.tbl_entity.Add(tbl_entity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.entity_owner = new SelectList(db.tbl_empoyee, "emp_id", "emp_name", tbl_entity.entity_owner);
            ViewBag.workflow_id = new SelectList(db.Work_flow_tbl, "work_flow_id", "work_flow_name", tbl_entity.workflow_id);
            return View(tbl_entity);
        }

        // GET: tbl_entity/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_entity tbl_entity = db.tbl_entity.Find(id);
            if (tbl_entity == null)
            {
                return HttpNotFound();
            }
            ViewBag.entity_owner = new SelectList(db.tbl_empoyee, "emp_id", "emp_name", tbl_entity.entity_owner);
            ViewBag.workflow_id = new SelectList(db.Work_flow_tbl, "work_flow_id", "work_flow_name", tbl_entity.workflow_id);
            return View(tbl_entity);
        }

        // POST: tbl_entity/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "entity_id,entity_name,action_name,action_description,entry_criteria,exit_criteria,entity_owner,entity_status,change_status,workflow_id")] tbl_entity tbl_entity)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_entity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.entity_owner = new SelectList(db.tbl_empoyee, "emp_id", "emp_name", tbl_entity.entity_owner);
            ViewBag.workflow_id = new SelectList(db.Work_flow_tbl, "work_flow_id", "work_flow_name", tbl_entity.workflow_id);
            return View(tbl_entity);
        }

        // GET: tbl_entity/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_entity tbl_entity = db.tbl_entity.Find(id);
            if (tbl_entity == null)
            {
                return HttpNotFound();
            }
            return View(tbl_entity);
        }

        // POST: tbl_entity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_entity tbl_entity = db.tbl_entity.Find(id);
            db.tbl_entity.Remove(tbl_entity);
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
