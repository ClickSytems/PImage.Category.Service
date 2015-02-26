namespace PImage.Category.Service.WebAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Properties_Checked : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.SubCategories", "CategoryId");
            AddForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories", "Id", cascadeDelete: true);
        }
    }
}
