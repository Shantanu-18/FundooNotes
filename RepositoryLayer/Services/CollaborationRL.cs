using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class CollaborationRL : ICollaborationRL
    {
        private UserContext _userContext;
        Collaboration collaboration = new Collaboration();

        public CollaborationRL(UserContext userContext)
        {
            _userContext = userContext;
        }

        public bool AddCollab(long noteId, long userId, string collabEmail)
        {
            try
            {
                var result = _userContext.Collaborations.FirstOrDefault(e => e.NoteId == noteId
                                                                            && e.UserId == userId
                                                                            && e.CollabEmail == collabEmail);
                if (result == null)
                {
                    collaboration.CollabEmail = collabEmail;
                    collaboration.UserId = userId;
                    collaboration.NoteId = noteId;
                    _userContext.Collaborations.Add(collaboration);

                    var changes = _userContext.SaveChanges();

                    if (changes > 0) return true;

                    else return false;
                }

                else return false;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Collaboration> GetCollab(long noteId, long userId)
        {
            try
            {
                var result = _userContext.Collaborations.Where(e => e.NoteId == noteId && e.UserId == userId).ToList();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool RemoveCollab(long noteId, long userId, string collabEmail)
        {
            try
            {
                var result = _userContext.Collaborations.FirstOrDefault(e => e.NoteId == noteId
                                                                            && e.UserId == userId
                                                                            && e.CollabEmail == collabEmail);

                if (result != null)
                {
                    _userContext.Collaborations.Remove(result);
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
