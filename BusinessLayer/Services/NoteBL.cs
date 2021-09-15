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

        public List<Note> GetAllNotes()
        {
            try
            {
                return _noteRL.GetAllNotes();
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
    }
}
