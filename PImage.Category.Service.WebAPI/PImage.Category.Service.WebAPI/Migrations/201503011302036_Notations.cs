namespace PImage.Category.Service.WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Notations : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Fields", new[] { "SubCategoryID" });
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        SubCategoryId = c.Int(nullable: false),
                        FieldsId = c.Int(nullable: false),
                        Value = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.Categories", "Description", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Categories", "Slug", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Fields", "Description", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.Fields", "Type", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.FieldValues", "FieldValue", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.SubCategories", "Description", c => c.String(nullable: false, maxLength: 60));
            AlterColumn("dbo.SubCategories", "Slug", c => c.String(nullable: false, maxLength: 60));
            CreateIndex("dbo.Fields", "SubCategoryId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Fields", new[] { "SubCategoryId" });
            AlterColumn("dbo.SubCategories", "Slug", c => c.String());
            AlterColumn("dbo.SubCategories", "Description", c => c.String());
            AlterColumn("dbo.FieldValues", "FieldValue", c => c.String());
            AlterColumn("dbo.Fields", "Type", c => c.String());
            AlterColumn("dbo.Fields", "Description", c => c.String());
            AlterColumn("dbo.Categories", "Slug", c => c.String());
            AlterColumn("dbo.Categories", "Description", c => c.String());
            DropTable("dbo.Products");
            CreateIndex("dbo.Fields", "SubCategoryID");
        }
    }
}
