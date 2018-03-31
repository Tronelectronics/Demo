using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Demo;
using Demo.Service;

namespace Demo.Controllers
{
    public class SchedulesManagementController : Controller
    {
        private DemoEntities db = new DemoEntities();

        // GET: SchedulesManagement
        public ActionResult Index()
        {
            //return View(db.Schedule.ToList());

            List<string> shiftA = new List<string>();
            shiftA.Add("A1");
            shiftA.Add("A2");
            shiftA.Add("A3");

            List<string> shiftB = new List<string>();
            shiftB.Add("B1");
            shiftB.Add("B2");
            shiftB.Add("B3");

            List<string> shiftC = new List<string>();
            shiftC.Add("C1");
            shiftC.Add("C2");
            shiftC.Add("C3");

            DateTime startDate = DateTime.Parse("2018-01-01");
            DateTime endDate = DateTime.Parse("2018-01-31");

            ShiftService shiftService = new ShiftService();
            List<string> shiftNames = shiftService.GetAllShiftNames();

            ScheduleService scheduleService = new ScheduleService();
            List<Models.Schedule> schedules = scheduleService.Generate(shiftA, shiftB, shiftC, startDate, endDate, shiftNames);

            return View(schedules.ToList());
        }

        // GET: SchedulesManagement/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedule.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // GET: SchedulesManagement/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SchedulesManagement/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Date,EmployeeName,Id,ShiftName")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                schedule.Id = Guid.NewGuid();
                db.Schedule.Add(schedule);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(schedule);
        }

        // GET: SchedulesManagement/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedule.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: SchedulesManagement/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Date,EmployeeName,Id,ShiftName")] Schedule schedule)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedule).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(schedule);
        }

        // GET: SchedulesManagement/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Schedule schedule = db.Schedule.Find(id);
            if (schedule == null)
            {
                return HttpNotFound();
            }
            return View(schedule);
        }

        // POST: SchedulesManagement/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Schedule schedule = db.Schedule.Find(id);
            db.Schedule.Remove(schedule);
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
