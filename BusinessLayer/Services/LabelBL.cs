using BusinessLayer.Interface;
using CommonLayer;
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
                return _labelRL.AddLabel(noteId,userId,labelModel);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
