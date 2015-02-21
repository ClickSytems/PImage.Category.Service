namespace PImage.Category.DTO
{
    using System;
    using System.Collections.Generic;
    
    public class ProductsView
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int SubCategoryID { get; set; }
        public string SubCategoryDescription { get; set; }
        public Nullable<int> FieldId { get; set; }
        public string FieldDescription { get; set; }
        public Nullable<int> FieldOrder { get; set; }
        public string Value { get; set; }
    }
}
