namespace PImage.Category.DTO
{
    using System.Collections.Generic;
    
    public class Field
    {
        public Field()
        {
            this.FieldValues = new HashSet<FieldValues>();
        }
    
        public int SubCategoryId { get; set; }
        public int Order { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Id { get; set; }
    
        public ICollection<FieldValues> FieldValues { get; set; }

    }
}
