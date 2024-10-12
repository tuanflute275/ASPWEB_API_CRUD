namespace LearningAPI.Models.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Image { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
    }
}
