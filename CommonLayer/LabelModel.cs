using System.ComponentModel.DataAnnotations;

namespace CommonLayer
{
    public class LabelModel
    {
        [Required]
        public string labelName { get; set; }
    }
}
