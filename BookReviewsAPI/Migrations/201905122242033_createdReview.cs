namespace BookReviewsAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createdReview : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BookReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BookTitle = c.String(),
                        Url = c.String(),
                        PublicationDt = c.String(),
                        Byline = c.String(),
                        BookAuthor = c.String(),
                        Summary = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BookReviews");
        }
    }
}
