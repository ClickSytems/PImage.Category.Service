namespace PImage.Category.Service.WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Product_Removed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Slug = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        Slug = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Fields",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubCategoryID = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        Description = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryID, cascadeDelete: true)
                .Index(t => t.SubCategoryID);
            
            CreateTable(
                "dbo.FieldValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FieldId = c.Int(nullable: false),
                        Order = c.Int(nullable: false),
                        FieldValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fields", t => t.FieldId, cascadeDelete: true)
                .Index(t => t.FieldId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Fields", "SubCategoryID", "dbo.SubCategories");
            DropForeignKey("dbo.FieldValues", "FieldId", "dbo.Fields");
            DropIndex("dbo.FieldValues", new[] { "FieldId" });
            DropIndex("dbo.Fields", new[] { "SubCategoryID" });
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            DropTable("dbo.FieldValues");
            DropTable("dbo.Fields");
            DropTable("dbo.SubCategories");
            DropTable("dbo.Categories");
        }
    }
}
