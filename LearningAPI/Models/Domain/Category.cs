using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LearningAPI.Models.Domain
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }
        [Column]
        public bool Status { get; set; }

        [Column]
        [DefaultValue("getdate()")]
        public DateTime? CreatedDate { get; set; } = DateTime.Now;

        public virtual ICollection<Product> Products { get; set; }
    }
}
