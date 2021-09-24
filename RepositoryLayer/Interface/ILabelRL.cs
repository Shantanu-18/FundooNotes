using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface ILabelRL
    {
        bool AddLabel(long noteId, long userId, LabelModel labelModel);

        List<Label> GetNoteLables(long noteId, long userId);

        bool AddLabelToUser(long userId, LabelModel labelModel);

        List<Label> GetUserLabels(long userId);

        bool EditLabelName(long labelId, long userId, LabelModel labelModel);

        bool RemoveLabel(long labelId, long noteId, long userId);

        bool DeleteLabel(long userId, string labelName);

        bool AddNoteToExistingLabel(long noteId, long userId, LabelModel labelModel);
    }
}
