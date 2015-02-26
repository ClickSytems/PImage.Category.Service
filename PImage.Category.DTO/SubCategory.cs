namespace PImage.Category.DTO
{
    using System.Collections.Generic;
    
    public class SubCategory
    {
        public SubCategory()
        {
            this.Fields = new HashSet<Field>();
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int CategoryId { get; set; }
    
        public ICollection<Field> Fields { get; set; }

    }
}
