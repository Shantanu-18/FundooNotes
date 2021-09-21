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

        bool IsPinned(long noteId, long userId);

        bool IsTrash(long noteId, long userId);

        bool IsArchive(long noteId, long userId);

        List<Note> GetTrash(long userId);

        List<Note> GetArchived(long userId);

        bool EmptyTrash(long userId);

        bool DeleteForever(long noteId, long userId);

        bool Restore(long noteId, long userId);

        bool UnArchive(long noteId, long userId);

        bool AddRemainder(long noteId, long userId, DateTime dateTime);

        bool DeleteRemainder(long noteId, long userId);

        bool ChangeRemainder(long noteId, long userId, DateTime dateTime);
    }
}
