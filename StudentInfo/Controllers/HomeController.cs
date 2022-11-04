using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StudentInfo.Models;

namespace StudentInfo.Controllers
{
    public class HomeController : Controller
    {
        private StudentDetailsEntities db = new StudentDetailsEntities();

        // GET: Home
        public async Task<ActionResult> Index()
        {
            return View(await db.tblStundentInfoes.ToListAsync());
        }

        // GET: Home/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStundentInfo tblStundentInfo = await db.tblStundentInfoes.FindAsync(id);
            if (tblStundentInfo == null)
            {
                return HttpNotFound();
            }
            return View(tblStundentInfo);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Student_Name,Student_Mobile,Student_Address,Student_Dept,Student_ID")] tblStundentInfo tblStundentInfo)
        {
            if (ModelState.IsValid)
            {
                db.tblStundentInfoes.Add(tblStundentInfo);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(tblStundentInfo);
        }

        // GET: Home/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStundentInfo tblStundentInfo = await db.tblStundentInfoes.FindAsync(id);
            if (tblStundentInfo == null)
            {
                return HttpNotFound();
            }
            return View(tblStundentInfo);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Student_Name,Student_Mobile,Student_Address,Student_Dept,Student_ID")] tblStundentInfo tblStundentInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblStundentInfo).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tblStundentInfo);
        }

        // GET: Home/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblStundentInfo tblStundentInfo = await db.tblStundentInfoes.FindAsync(id);
            if (tblStundentInfo == null)
            {
                return HttpNotFound();
            }
            return View(tblStundentInfo);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblStundentInfo tblStundentInfo = await db.tblStundentInfoes.FindAsync(id);
            db.tblStundentInfoes.Remove(tblStundentInfo);
            await db.SaveChangesAsync();
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
