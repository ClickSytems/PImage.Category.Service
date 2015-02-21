namespace PImage.Category.DTO
{
    using System;
    using System.Collections.Generic;
    
    public class FieldValues
    {
        public int Id { get; set; }
        public int FieldId { get; set; }
        public int Order { get; set; }
        public string FieldValue { get; set; }
    
        public virtual Field Field { get; set; }
    }
}
