namespace PImage.Category.DTO
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity;
    
    public class SubCategory
    {
        public SubCategory()
        {
            this.Fields = new HashSet<Field>();
        }
    
        public int Id { get; set; }

        [Display(Name = "Descri��o")]
        [DataType(DataType.Text)]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Slug")]
        [DataType(DataType.Text)]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Slug { get; set; }

        [Display(Name = "C�digo da Categoria")]
        [Required]
        public int CategoryId { get; set; }
    
        public ICollection<Field> Fields { get; set; }

    }
}
