namespace PImage.Category.DTO
{

    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public int FieldsId { get; set; }
        public string Value { get; set; }
    }
}
