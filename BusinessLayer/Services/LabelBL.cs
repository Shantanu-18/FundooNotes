using BusinessLayer.Interface;
using CommonLayer;
using RepositoryLayer.Entity;
using RepositoryLayer.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Services
{
    public class LabelBL : ILabelBL
    {
        private ILabelRL _labelRL;

        public LabelBL(ILabelRL labelRL)
        {
            _labelRL = labelRL;
        }
        public bool AddLabel(long noteId, long userId, LabelModel labelModel)
        {
            try
            {
                return _labelRL.AddLabel(noteId, userId, labelModel);
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
                return _labelRL.AddLabelToUser(userId, labelModel);
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
                return _labelRL.GetNoteLables(noteId, userId);
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
                return _labelRL.GetUserLabels(userId);
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
                return _labelRL.EditLabelName(labelId, userId, labelModel);
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
                return _labelRL.RemoveLabel(labelId, noteId, userId);
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
                return _labelRL.DeleteLabel(userId, labelName);
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
                return _labelRL.AddNoteToExistingLabel(noteId, userId, labelName);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
