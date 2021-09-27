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

        public bool AddLabelToUser(long userId, LabelModel labelModel)
        {
            try
            {
                var checkLabel = _userContext.Labels.FirstOrDefault(l => l.LabelName == labelModel.labelName && l.UserId == userId);

                if (checkLabel == null)
                {
                    label.LabelName = labelModel.labelName;
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

        public List<Label> GetNoteLables(long noteId, long userId)
        {
            try
            {
                var result = _userContext.Labels.Where(l => l.NoteId == noteId && l.UserId == userId).ToList();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Label> GetUserLabels(long userId)
        {
            try
            {
                var result = _userContext.Labels.Where(l => l.UserId == userId).ToList();

                return result;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool EditLabelName(long labelId, long userId, LabelModel labelModel)
        {
            try
            {
                var result = _userContext.Labels.FirstOrDefault(e => e.LabelId == labelId && e.UserId == userId);
                var checkLabel = _userContext.Labels.FirstOrDefault(l => l.LabelName == labelModel.labelName && l.UserId == userId);

                if (result != null && checkLabel == null)
                {
                    result.LabelName = labelModel.labelName;

                    _userContext.SaveChanges();

                    return true;
                }
                else return false;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool RemoveLabel(long labelId, long noteId, long userId)
        {
            try
            {
                var result = _userContext.Labels.FirstOrDefault(e => e.LabelId == labelId && e.UserId == userId && e.NoteId == noteId);

                if (result != null)
                {
                    _userContext.Labels.Remove(result);
                    _userContext.SaveChanges();

                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool DeleteLabel(long userId, string labelName)
        {
            try
            {
                var result = _userContext.Labels.Where(e => e.UserId == userId && e.LabelName == labelName).ToList();

                if (result != null)
                {
                    _userContext.Labels.RemoveRange(result);
                    _userContext.SaveChanges();

                    return true;
                }
                else return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddNoteToExistingLabel(long noteId, long userId, string labelName)
        {
            try
            {
                var checkLabel = _userContext.Labels.FirstOrDefault(l => l.LabelName == labelName && l.UserId == userId);

                if (checkLabel != null)
                {
                    label.LabelName = labelName;
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
