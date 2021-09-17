using CommonLayer;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class NoteRL : INoteRL
    {
        private UserContext _userContext;
        Note note = new Note();

        public NoteRL(UserContext userContext)
        {
            _userContext = userContext;
        }

        public bool AddNotes(NotesModel notesModel, long userId)
        {
            try
            {
                note.Title = notesModel.Title;
                note.Message = notesModel.Message;
                note.Remainder = notesModel.Remainder;
                note.Color = notesModel.Color;
                note.image = notesModel.image;
                note.isArchive = notesModel.isArchive;
                note.isTrash = notesModel.isTrash;
                note.isPin = notesModel.isPin;
                note.CreatedAt = DateTime.Now;
                note.ModifiedAt = null;
                note.UserId = userId;


                _userContext.Notes.Add(note);
                int result = _userContext.SaveChanges();

                if (result > 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public List<Note> GetAllNotes(long userId)
        {
            try
            {
                var result = _userContext.Notes.Where(e => e.UserId == userId).ToList();

                return result;
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
                var result = _userContext.Notes.FirstOrDefault(e => e.Id == id && e.UserId == userId);

                if (result != null)
                {
                    _userContext.Notes.Remove(result);
                    _userContext.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
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
                var result = _userContext.Notes.FirstOrDefault(e => e.Id == id && e.UserId == userId);

                if (result != null)
                {
                    if (notesModel.Title != null)
                    {
                        result.Title = notesModel.Title;
                    }
                    if (notesModel.Message != null)
                    {
                        result.Message = notesModel.Message;
                    }

                    result.ModifiedAt = DateTime.Now;
                    _userContext.SaveChanges();

                    return true;
                }
                else
                {
                    return false;
                }
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
                var result = _userContext.Notes.FirstOrDefault(e => e.Id == noteId && e.UserId == userId);

                if (result != null)
                {
                    result.Color = notesModel.Color;
                    result.ModifiedAt = DateTime.Now;
                }
                //_userContext.Notes.Add(result);
                int changes = _userContext.SaveChanges();

                if (changes > 0)
                {
                    return true;
                }
                else { return false; }
            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }
    }
}
