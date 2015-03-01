using System.Collections.Generic;

namespace PImage.Category.Service.WebAPI.Models
{
    public class EditViewModel
    {
        public DTO.Category Category { get; set; }
        public List<DTO.SubCategory> SubCategories { get; set; }
    }
}