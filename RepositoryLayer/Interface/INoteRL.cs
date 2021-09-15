﻿using CommonLayer;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RepositoryLayer.Interface
{
    public interface INoteRL
    {
        List<Note> GetAllNotes();

        bool AddNotes(NotesModel notesModel, long Id);

        bool DeleteNotes(long id, long userId);

        bool UpdateNotes(long id, long userId, NotesModel notesModel);
    }
}