using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using DTO = PImage.Category.DTO;


namespace PImage.Category.Service.WebAPI.Models
{

    public class CategoryContext : DbContext
    {
        public CategoryContext()
            : base("name=CategoryContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }

        public DbSet<DTO.Category> Category { get; set; }
        public DbSet<DTO.Field> Field { get; set; }
        public DbSet<DTO.FieldValues> FieldValues { get; set; }
        public DbSet<DTO.SubCategory> SubCategory { get; set; }
        public DbSet<DTO.Product> Product { get; set; }
        public DbSet<DTO.ProductsView> ProductsView { get; set; }
    }
}