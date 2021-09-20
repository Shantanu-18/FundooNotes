using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ICollaborationBL
    {
        bool AddCollab(long noteId, long userId, string collabEmail);
    }
}
