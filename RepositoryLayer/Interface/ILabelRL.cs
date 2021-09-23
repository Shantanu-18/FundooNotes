using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ILabelRL
    {
        bool AddLabel(long noteId, long userId, LabelModel labelModel);
    }
}
