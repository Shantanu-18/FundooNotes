using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryLayer.Entity
{
    public class Label
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long LabelId { get; set; }

        public string LabelName { get; set; }

        public long? NoteId { get; set; }

        public Note Notes { get; set; }

        public long UserId { get; set; }

        public User Users { get; set; }
    }
}
