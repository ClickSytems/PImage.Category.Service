namespace PImage.Category.DTO
{
    using System;
    using System.Collections.Generic;
    
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int FieldsId { get; set; }
        public string Value { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Field Field { get; set; }
        public virtual SubCategory SubCategory { get; set; }
    }
}
