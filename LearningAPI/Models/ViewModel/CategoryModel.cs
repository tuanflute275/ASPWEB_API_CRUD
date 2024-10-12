using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace LearningAPI.Models.ViewModel
{
    public class CategoryModel
    {
        public string Name { get; set; }
        public bool Status { get; set; }
    }
}
