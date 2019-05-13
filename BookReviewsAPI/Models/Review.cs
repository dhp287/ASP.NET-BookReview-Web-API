namespace BookReviewsAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class Review : DbContext
    {
        
        public Review()
            : base("name=Review")
        {
        }

        public virtual DbSet<BookReview> Entities { get; set; }
    }

    public class BookReview
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string Url { get; set; }
        public string PublicationDt { get; set; }
        public string Byline { get; set; }
        public string BookAuthor { get; set; }
        public string Summary { get; set; }
    }
}