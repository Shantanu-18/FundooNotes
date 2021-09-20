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
                var result = _userContext.Notes.Where(e => e.UserId == userId
                                                         && e.isArchive == false
                                                         && e.isTrash == false).ToList();

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
        }

        public bool IsPinned(long noteId, long userId)
        {
            try
            {
                var result = _userContext.Notes.FirstOrDefault(e => e.Id == noteId && e.UserId == userId);

                if (result != null)
                {
                    if (result.isPin == true)
                    {
                        result.isPin = false;
                    }
                    else if (result.isPin == false)
                    {
                        result.isPin = true;
                    }
                    result.ModifiedAt = DateTime.Now;
                }
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
        }

        public bool IsTrash(long noteId, long userId)
        {
            try
            {
                var result = _userContext.Notes.FirstOrDefault(e => e.Id == noteId && e.UserId == userId);

                if (result != null)
                {
                    result.isTrash = true;
                    result.isArchive = false;

                    result.ModifiedAt = DateTime.Now;
                }
                int changes = _userContext.SaveChanges();

                if (changes > 0) { return true; }

                else { return false; }
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
                var result = _userContext.Notes.FirstOrDefault(e => e.Id == noteId && e.UserId == userId);

                if (result != null)
                {
                    result.isArchive = true;
                    result.isTrash = false;

                    result.ModifiedAt = DateTime.Now;
                }
                int changes = _userContext.SaveChanges();

                if (changes > 0) return true;

                else return false;
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
                var result = _userContext.Notes.Where(e => e.UserId == userId && e.isTrash == true).ToList();

                return result;
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
                var result = _userContext.Notes.Where(e => e.UserId == userId && e.isArchive == true).ToList();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Note GetNoteId(long noteId, long userId)
        {
            var result = _userContext.Notes.FirstOrDefault(e => e.Id == noteId && e.UserId == userId);

            return result;
        }

        public bool EmptyTrash(long userId)
        {
            try
            {
                var result = _userContext.Notes.Where(note => note.isTrash == true && note.UserId == userId).ToList();

                if (result.Count > 0)
                {
                    _userContext.Notes.RemoveRange(result);
                    _userContext.SaveChanges();

                    return true;
                }
                else { return false; }
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
                var result = _userContext.Notes.FirstOrDefault(note => note.isTrash == true
                                                                    && note.UserId == userId
                                                                    && note.Id == noteId);

                if (result != null)
                {
                    _userContext.Notes.Remove(result);
                    _userContext.SaveChanges();

                    return true;
                }
                else { return false; }
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
                var result = _userContext.Notes.FirstOrDefault(e => e.Id == noteId && e.UserId == userId);

                if (result != null)
                {
                    result.isTrash = false;
                    result.isArchive = false;

                    result.ModifiedAt = DateTime.Now;
                }
                int changes = _userContext.SaveChanges();

                if (changes > 0) { return true; }

                else { return false; }
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
                var result = _userContext.Notes.FirstOrDefault(e => e.Id == noteId && e.UserId == userId);

                if (result != null)
                {
                    result.isArchive = false;
                    result.isTrash = false;

                    result.ModifiedAt = DateTime.Now;
                }
                int changes = _userContext.SaveChanges();

                if (changes > 0) return true;

                else return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
