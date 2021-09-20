using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ICollaborationRL
    {
        bool AddCollab(long noteId, long userId, string collabEmail);
    }
}
