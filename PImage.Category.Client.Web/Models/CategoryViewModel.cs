using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DTO = PImage.Category.DTO;

namespace PImage.Category.Client.Web.Models
{
    public class CategoryViewModel
    {
        public DTO.Category Category { get; set; }
        public List<DTO.SubCategory> SubCategories { get; set; }
    }
}