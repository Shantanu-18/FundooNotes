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
                collaboration.CollabEmail = collabEmail;
                collaboration.UserId = userId;
                collaboration.NoteId = noteId;
                _userContext.Collaborations.Add(collaboration);

                var changes = _userContext.SaveChanges();

                if (changes > 0) return true;

                else return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
