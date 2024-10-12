using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LearningAPI.Models.ViewModel
{
    public class ProductModel
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string image { get; set; }
        public bool Status { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
    }
}
