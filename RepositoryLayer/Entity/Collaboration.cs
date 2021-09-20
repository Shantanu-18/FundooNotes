using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RepositoryLayer.Entity
{
    public class Collaboration
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long CollabId { get; set; }

        public string CollabEmail { get; set; }

        public long NoteId { get; set; }

        public Note Notes { get; set; }

        public long? UserId { get; set; }

        public User Users { get; set; }
    }
}
