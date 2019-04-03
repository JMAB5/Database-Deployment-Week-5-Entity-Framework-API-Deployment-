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
    public class tblBooksController : ApiController
    {
        private Week_5_DatabaseEntities db = new Week_5_DatabaseEntities();

        // GET: api/tblBooks
        public IQueryable<tblBook> GettblBooks()
        {
            return db.tblBooks;
        }

        // GET: api/tblBooks/5
        [ResponseType(typeof(tblBook))]
        public IHttpActionResult GettblBook(string id)
        {
            tblBook tblBook = db.tblBooks.Find(id);
            if (tblBook == null)
            {
                return NotFound();
            }

            return Ok(tblBook);
        }

        // PUT: api/tblBooks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PuttblBook(string id, tblBook tblBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tblBook.ISBN)
            {
                return BadRequest();
            }

            db.Entry(tblBook).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tblBookExists(id))
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

        // POST: api/tblBooks
        [ResponseType(typeof(tblBook))]
        public IHttpActionResult PosttblBook(tblBook tblBook)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.tblBooks.Add(tblBook);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (tblBookExists(tblBook.ISBN))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tblBook.ISBN }, tblBook);
        }

        // DELETE: api/tblBooks/5
        [ResponseType(typeof(tblBook))]
        public IHttpActionResult DeletetblBook(string id)
        {
            tblBook tblBook = db.tblBooks.Find(id);
            if (tblBook == null)
            {
                return NotFound();
            }

            db.tblBooks.Remove(tblBook);
            db.SaveChanges();

            return Ok(tblBook);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool tblBookExists(string id)
        {
            return db.tblBooks.Count(e => e.ISBN == id) > 0;
        }
    }
}