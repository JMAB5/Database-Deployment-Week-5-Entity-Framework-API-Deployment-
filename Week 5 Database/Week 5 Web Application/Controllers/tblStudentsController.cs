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
using Week_5_Web_Application.Models;

namespace Week_5_Web_Application.Controllers
{
    public class tblStudentsController : ApiController
    {
        private Week_5_DatabaseEntities2 db = new Week_5_DatabaseEntities2();

        // GET: api/tblStudents
        public IQueryable<tblStudent> GettblStudents()
        {
            return db.tblStudents;
        }

        // GET: api/tblStudents/5
        [ResponseType(typeof(tblStudent))]
        public IHttpActionResult GettblStudent(string id)
        {
            tblStudent tblStudent = db.tblStudents.Find(id);
            if (tblStudent == null)
            {
                return NotFound();
            }

            return Ok(tblStudent);
        }

        // PUT: api/tblStudents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblStudent(string id, tblStudent tblStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblStudent.StudentID)
            {
                return BadRequest();
            }

            db.Entry(tblStudent).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblStudentExists(id))
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

        // POST: api/tblStudents
        [ResponseType(typeof(tblStudent))]
        public IHttpActionResult PosttblStudent(tblStudent tblStudent)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblStudents.Add(tblStudent);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tblStudentExists(tblStudent.StudentID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tblStudent.StudentID }, tblStudent);
        }

        // DELETE: api/tblStudents/5
        [ResponseType(typeof(tblStudent))]
        public IHttpActionResult DeletetblStudent(string id)
        {
            tblStudent tblStudent = db.tblStudents.Find(id);
            if (tblStudent == null)
            {
                return NotFound();
            }

            db.tblStudents.Remove(tblStudent);
            db.SaveChanges();

            return Ok(tblStudent);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblStudentExists(string id)
        {
            return db.tblStudents.Count(e => e.StudentID == id) > 0;
        }
    }
}