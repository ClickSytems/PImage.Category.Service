using System.Data.Entity;

namespace PImage.Category.DataModel
{
    public class CategoryDataContext : DbContext
    {
        public DbSet<DTO.Category> Category { get; set; }
        public DbSet<DTO.SubCategory> SubCategory { get; set; }
        public DbSet<DTO.Field> Field { get; set; }
        public DbSet<DTO.FieldValues> FieldValues { get; set; }
        public System.Data.Entity.DbSet<DTO.Product> Products { get; set; }
    }
}
