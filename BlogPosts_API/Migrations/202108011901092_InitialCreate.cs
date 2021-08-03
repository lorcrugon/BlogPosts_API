namespace BlogPosts_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BlogPosts",
                c => new
                    {
                        BlogPostId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Body = c.String(),
                        AuthorId = c.Int(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.BlogPostId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BlogPosts");
        }
    }
}
