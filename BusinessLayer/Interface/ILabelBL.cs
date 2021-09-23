using CommonLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interface
{
    public interface ILabelBL
    {
        bool AddLabel(long noteId, long userId, LabelModel labelModel);
    }
}
