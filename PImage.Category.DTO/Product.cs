using System.ComponentModel.DataAnnotations;
namespace PImage.Category.DTO
{

    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int FieldsId { get; set; }

        [Display(Name = "Valor do Campo")]
        [DataType(DataType.Text)]
        [StringLength(10, MinimumLength = 1)]
        [Required]
        public string Value { get; set; }
    }
}
