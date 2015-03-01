using System.ComponentModel.DataAnnotations;
namespace PImage.Category.DTO
{

    public class FieldValues
    {
        public int Id { get; set; }

        [Display(Name = "Código do campo")]
        [Required]
        public int FieldId { get; set; }

        [Display(Name = "Ordem")]
        [Required]
        public int Order { get; set; }

        [Display(Name = "Valor do Campo")]
        [DataType(DataType.Text)]
        [StringLength(10, MinimumLength = 1)]
        [Required]
        public string FieldValue { get; set; }
    
   }
}
