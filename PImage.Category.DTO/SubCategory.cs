namespace PImage.Category.DTO
{
    using System;
    using System.Collections.Generic;
    
    public class SubCategory
    {
        public SubCategory()
        {
            this.Field = new HashSet<Field>();
            this.Product = new HashSet<Product>();
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int CategoryId { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ICollection<Field> Field { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
