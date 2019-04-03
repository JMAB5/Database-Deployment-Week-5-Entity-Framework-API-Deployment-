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
    public class tblBorrowsController : ApiController
    {
        private Week_5_DatabaseEntities3 db = new Week_5_DatabaseEntities3();

        // GET: api/tblBorrows
        public IQueryable<tblBorrow> GettblBorrows()
        {
            return db.tblBorrows;
        }

        // GET: api/tblBorrows/5
        [ResponseType(typeof(tblBorrow))]
        public IHttpActionResult GettblBorrow(int id)
        {
            tblBorrow tblBorrow = db.tblBorrows.Find(id);
            if (tblBorrow == null)
            {
                return NotFound();
            }

            return Ok(tblBorrow);
        }

        // PUT: api/tblBorrows/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblBorrow(int id, tblBorrow tblBorrow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblBorrow.BorrowID)
            {
                return BadRequest();
            }

            db.Entry(tblBorrow).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblBorrowExists(id))
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

        // POST: api/tblBorrows
        [ResponseType(typeof(tblBorrow))]
        public IHttpActionResult PosttblBorrow(tblBorrow tblBorrow)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblBorrows.Add(tblBorrow);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = tblBorrow.BorrowID }, tblBorrow);
        }

        // DELETE: api/tblBorrows/5
        [ResponseType(typeof(tblBorrow))]
        public IHttpActionResult DeletetblBorrow(int id)
        {
            tblBorrow tblBorrow = db.tblBorrows.Find(id);
            if (tblBorrow == null)
            {
                return NotFound();
            }

            db.tblBorrows.Remove(tblBorrow);
            db.SaveChanges();

            return Ok(tblBorrow);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblBorrowExists(int id)
        {
            return db.tblBorrows.Count(e => e.BorrowID == id) > 0;
        }
    }
}