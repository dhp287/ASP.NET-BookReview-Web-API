using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using BookReviewsAPI.Models;

namespace BookReviewsAPI.Controllers
{
    [Authorize]
    public class BookReviewsController : ODataController
    {
        private Review db = new Review();

        // GET: odata/BookReviews
        [EnableQuery]
        public IQueryable<BookReview> GetBookReviews()
        {
            return db.Entities;
        }

        // POST: odata/BookReviews
        public IHttpActionResult Post(BookReview bookReview)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Entities.Add(bookReview);
            db.SaveChanges();

            return Created(bookReview);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookReviewExists(int key)
        {
            return db.Entities.Count(e => e.Id == key) > 0;
        }
    }
}
