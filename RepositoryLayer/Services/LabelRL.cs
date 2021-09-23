using CommonLayer;
using RepositoryLayer.Context;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepositoryLayer.Services
{
    public class LabelRL : ILabelRL
    {
        private UserContext _userContext;
        Label label = new Label();

        public LabelRL(UserContext userContext)
        {
            _userContext = userContext;
        }

        public bool AddLabel(long noteId, long userId, LabelModel labelModel)
        {
            try
            {
                var checkLabel = _userContext.Labels.FirstOrDefault(l => l.LabelName == labelModel.labelName && l.UserId == userId);

                if (checkLabel == null)
                {
                    label.LabelName = labelModel.labelName;
                    label.NoteId = noteId;
                    label.UserId = userId;

                    _userContext.Labels.Add(label);
                    int changes = _userContext.SaveChanges();

                    if (changes > 0) return true;

                    else return false;
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
