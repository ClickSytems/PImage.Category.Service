namespace PImage.Category.DTO
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public class Field
    {
        public Field()
        {
            this.FieldValues = new HashSet<FieldValues>();
        }

        [Display(Name = "Código da SubCategoria")]
        [Required]
        public int SubCategoryId { get; set; }

        [Display(Name = "Ordem")]
        [Required]
        public int Order { get; set; }

        [Display(Name = "Descrição")]
        [DataType(DataType.Text)]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Tipo")]
        [DataType(DataType.Text)]
        [StringLength(10, MinimumLength = 3)]
        [Required]
        public string Type { get; set; }

        public int Id { get; set; }
    
        public ICollection<FieldValues> FieldValues { get; set; }

    }
}
