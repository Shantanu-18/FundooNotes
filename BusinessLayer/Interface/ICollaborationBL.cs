using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ICollaborationBL
    {
        bool AddCollab(long noteId, long userId, string collabEmail);

        List<Collaboration> GetCollab(long noteId, long userId);

        bool RemoveCollab(long noteId, long userId, string collabEmail);
    }
}
