using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAPI.Models.Domain
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Image { get; set; }
        [Column]
        public bool Status { get; set; }

        [Column(TypeName = "ntext")]
        public string Description { get; set; }

        // foreign key table
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

    }
}
