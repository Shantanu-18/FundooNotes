using RepositoryLayer.Entity;
using System.Collections.Generic;

namespace RepositoryLayer.Interface
{
    public interface ICollaborationRL
    {
        bool AddCollab(long noteId, long userId, string collabEmail);

        List<Collaboration> GetCollab(long noteId, long userId);

        bool RemoveCollab(long noteId, long userId, string collabEmail);
    }
}
