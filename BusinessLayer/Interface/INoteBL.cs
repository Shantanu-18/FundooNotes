using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface INoteBL
    {
        List<Note> GetAllNotes(long userId);

        bool AddNotes(NotesModel notesModel, long Id);

        bool DeleteNotes(long id, long userId);

        bool UpdateNotes(long id, long userId, NotesModel notesModel);
        bool ChangeColor(long noteId, long userId, NotesModel notesModel);
    }
}
