//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PImage.Category.DataModel
{
    using System;
    using System.Collections.Generic;
    
    public partial class SubCategory
    {
        public SubCategory()
        {
            this.Field = new HashSet<Field>();
            this.Product = new HashSet<Product>();
        }
    
        public int Id { get; set; }
        public string Description { get; set; }
        public string Slug { get; set; }
        public int CategoryId { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual ICollection<Field> Field { get; set; }
        public virtual ICollection<Product> Product { get; set; }
    }
}