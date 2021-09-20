using BusinessLayer.Interface;
using CommonLayer;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class NoteBL : INoteBL
    {
        private INoteRL _noteRL;

        public NoteBL(INoteRL noteRL)
        {
            _noteRL = noteRL;
        }

        public bool AddNotes(NotesModel notesModel, long Id)
        {
            try
            {
                return _noteRL.AddNotes(notesModel, Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Note> GetAllNotes(long userId)
        {
            try
            {
                return _noteRL.GetAllNotes(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteNotes(long id, long userId)
        {
            try
            {
                return this._noteRL.DeleteNotes(id, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UpdateNotes(long id, long userId, NotesModel notesModel)
        {
            try
            {
                return this._noteRL.UpdateNotes(id, userId, notesModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ChangeColor(long noteId, long userId, NotesModel notesModel)
        {
            try
            {
                return this._noteRL.ChangeColor(noteId, userId, notesModel);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsPinned(long noteId, long userId)
        {
            try
            {
                return _noteRL.IsPinned(noteId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsTrash(long noteId, long userId, bool value)
        {
            try
            {
                return _noteRL.IsTrash(noteId, userId, value);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsArchive(long noteId, long userId, bool value)
        {
            try
            {
                return _noteRL.IsArchive(noteId, userId, value);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Note> GetTrash(long userId)
        {
            try
            {
                return _noteRL.GetTrash(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Note> GetArchived(long userId)
        {
            try
            {
                return _noteRL.GetArchived(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
