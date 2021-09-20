using BusinessLayer.Interface;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using RepositoryLayer.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class CollaborationBL : ICollaborationBL
    {
        private ICollaborationRL _collaborationRL;
        private INoteRL _noteRL;
        private IUserRL _userRL;

        public CollaborationBL(ICollaborationRL collaborationRL, INoteRL noteRL, IUserRL userRL)
        {
            _collaborationRL = collaborationRL;
            _noteRL = noteRL;
            _userRL = userRL;
        }

        public bool AddCollab(long noteId, long userId, string collabEmail)
        {
            try
            {
                var checkNote = _noteRL.GetNoteId(noteId, userId);
                var checkEmail = _userRL.GetEmail(collabEmail);

                if (checkNote == null)
                {
                    return false;
                }

                if (checkEmail == null)
                {
                    return false;
                }
                return _collaborationRL.AddCollab(noteId, userId, collabEmail);
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
                return _collaborationRL.GetCollab(noteId, userId);
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
                return _collaborationRL.RemoveCollab(noteId, userId, collabEmail);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
