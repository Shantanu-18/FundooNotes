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

        public NoteRL(UserContext userContext)
        {
            _userContext = userContext;
        }

        public bool AddNotes(NotesModel notesModel, long userId)
        {
            try
            {
                Note note = new Note();
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


        public List<Note> GetAllNotes()
        {
            try
            {
                var result = _userContext.Notes.ToList();

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
    }
}
