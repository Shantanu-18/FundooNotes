using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
    public class NotesModel
    {
        public string Title { get; set; }

        public string Message { get; set; }

        public DateTime Remainder { get; set; }

        public string Color { get; set; }

        public string image { get; set; }

        public bool isArchive { get; set; }

        public bool isTrash { get; set; }

        public bool isPin { get; set; }
    }
}
