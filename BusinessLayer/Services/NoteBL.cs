using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Http;
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

        public List<Note> GetAllNotes(long userId, string userEmail)
        {
            try
            {
                return _noteRL.GetAllNotes(userId, userEmail);
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

        public bool IsTrash(long noteId, long userId)
        {
            try
            {
                return _noteRL.IsTrash(noteId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool IsArchive(long noteId, long userId)
        {
            try
            {
                return _noteRL.IsArchive(noteId, userId);
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

        public bool EmptyTrash(long userId)
        {
            try
            {
                return _noteRL.EmptyTrash(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteForever(long noteId, long userId)
        {
            try
            {
                return _noteRL.DeleteForever(noteId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Restore(long noteId, long userId)
        {
            try
            {
                return _noteRL.Restore(noteId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool UnArchive(long noteId, long userId)
        {
            try
            {
                return _noteRL.UnArchive(noteId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddRemainder(long noteId, long userId, DateTime dateTime)
        {
            try
            {
                return _noteRL.AddRemainder(noteId, userId, dateTime);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteRemainder(long noteId, long userId)
        {
            try
            {
                return _noteRL.DeleteRemainder(noteId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool ChangeRemainder(long noteId, long userId, DateTime dateTime)
        {
            try
            {
                return _noteRL.ChangeRemainder(noteId, userId, dateTime);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddImage(long noteId, long userId, IFormFile formFile)
        {
            try
            {
                return _noteRL.AddImage(noteId, userId, formFile);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteImage(long noteId, long userId)
        {
            try
            {
                return _noteRL.DeleteImage(noteId, userId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
