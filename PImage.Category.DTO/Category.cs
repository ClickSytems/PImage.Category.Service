
namespace PImage.Category.DTO
{
    using System;
    using System.Collections.Generic;
    
    public class Category
    {
        public Category()
        {
            this.Product = new HashSet<Product>();
            this.SubCategory = new HashSet<SubCategory>();
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
    
        public virtual ICollection<Product> Product { get; set; }
        public virtual ICollection<SubCategory> SubCategory { get; set; }
    }
}
