namespace PImage.Category.DTO
{
    using System;
    using System.Collections.Generic;
    
    public class Field
    {
        public Field()
        {
            this.FieldValues = new HashSet<FieldValues>();
            this.Product = new HashSet<Product>();
        }
    
        public int SubCategoryID { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Id { get; set; }
    
        public virtual SubCategory SubCategory { get; set; }
        public virtual ICollection<FieldValues> FieldValues { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}
