﻿namespace BlogPosts_API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BlogPosts", "Title", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.BlogPosts", "Body", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BlogPosts", "Body", c => c.String());
            AlterColumn("dbo.BlogPosts", "Title", c => c.String());
        }
    }
}
