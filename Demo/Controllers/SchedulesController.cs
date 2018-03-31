using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Demo;

namespace Demo.Controllers
{
    public class SchedulesController : ApiController
    {
        private DemoEntities db = new DemoEntities();

        // GET: api/Schedules
        public IQueryable<Schedule> GetSchedule()
        {
            return db.Schedule;
        }

        // GET: api/Schedules/5
        [ResponseType(typeof(Schedule))]
        public IHttpActionResult GetSchedule(Guid id)
        {
            Schedule schedule = db.Schedule.Find(id);
            if (schedule == null)
            {
                return NotFound();
            }

            return Ok(schedule);
        }

        // PUT: api/Schedules/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSchedule(Guid id, Schedule schedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != schedule.Id)
            {
                return BadRequest();
            }

            db.Entry(schedule).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScheduleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Schedules
        [ResponseType(typeof(Schedule))]
        public IHttpActionResult PostSchedule(Schedule schedule)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Schedule item = db.Schedule.FirstOrDefault(a => a.Date == schedule.Date && a.ShiftName == schedule.ShiftName);

            if (item == null)
            {
                schedule.Id = Guid.NewGuid();

                db.Schedule.Add(schedule);
            }
            else
            {
                item.EmployeeName = schedule.EmployeeName;
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ScheduleExists(schedule.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = schedule.Id }, schedule);
        }

        // DELETE: api/Schedules/5
        [ResponseType(typeof(Schedule))]
        public IHttpActionResult DeleteSchedule(Guid id)
        {
            Schedule schedule = db.Schedule.Find(id);
            if (schedule == null)
            {
                return NotFound();
            }

            db.Schedule.Remove(schedule);
            db.SaveChanges();

            return Ok(schedule);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScheduleExists(Guid id)
        {
            return db.Schedule.Count(e => e.Id == id) > 0;
        }
    }
}