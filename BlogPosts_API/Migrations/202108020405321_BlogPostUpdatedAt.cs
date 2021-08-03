namespace BlogPosts_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BlogPostUpdatedAt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BlogPosts", "UpdatedAt", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BlogPosts", "UpdatedAt");
        }
    }
}
