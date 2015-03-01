namespace PImage.Category.Client.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Client : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Categories", "Description", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Categories", "Slug", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Fields", "Description", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Fields", "Type", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.FieldValues", "FieldValue", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.SubCategories", "Description", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.SubCategories", "Slug", c => c.String(nullable: false, maxLength: 60));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SubCategories", "Slug", c => c.String());
            AlterColumn("dbo.SubCategories", "Description", c => c.String());
            AlterColumn("dbo.FieldValues", "FieldValue", c => c.String());
            AlterColumn("dbo.Fields", "Type", c => c.String());
            AlterColumn("dbo.Fields", "Description", c => c.String());
            AlterColumn("dbo.Categories", "Slug", c => c.String());
            AlterColumn("dbo.Categories", "Description", c => c.String());
        }
    }
}
