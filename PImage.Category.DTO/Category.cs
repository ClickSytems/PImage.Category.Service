using System.ComponentModel.DataAnnotations;
namespace PImage.Category.DTO
{

    public class Category
    {
        public Category()
        {

        }

        public int Id { get; set; }

        [Display(Name = "Descrição")]
        [DataType(DataType.Text)]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Description { get; set; }

        [Display(Name = "Slug")]
        [DataType(DataType.Text)]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string Slug { get; set; }

    }
}
