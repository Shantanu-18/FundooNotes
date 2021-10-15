using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace FundooNotes.Controllers
{
    [Authorize]
    [Route("notes")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private INoteBL _noteBL;

        public NoteController(INoteBL noteBL)
        {
            _noteBL = noteBL;
        }

        private long GetTokenId()
        {
            return Convert.ToInt64(User.FindFirst("Id").Value);
        }

        private string GetEmail()
        {
            return User.FindFirst(ClaimTypes.Email).Value.ToString();
        }

        [HttpPost]
        public IActionResult AddNote(NotesModel notesModel)
        {
            try
            {
                long UserID = GetTokenId();
                bool result = _noteBL.AddNotes(notesModel, UserID);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Note added Successfully !!" });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Adding Note was unsuccessfull !!" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpGet]
        public IActionResult GetNotes()
        {
            try
            {
                long userId = GetTokenId();
                string userEmail = GetEmail();
                List<Note> NotesList = _noteBL.GetAllNotes(userId, userEmail);

                if (NotesList.Count != 0)
                {
                    return this.Ok(new { Success = true, message = "These are Your all the notes.", Data = NotesList });
                }
                else if (NotesList.Count == 0)
                {
                    return Ok(new { Success = true, message = "Nothing is added in notes." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Something went wrong." });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpGet]
        [Route("Archived")]
        public IActionResult GetArchived()
        {
            try
            {
                long userId = GetTokenId();
                var archivedList = _noteBL.GetArchived(userId);

                if (archivedList.Count != 0)
                {
                    return this.Ok(new { Success = true, message = "These are your Archived Notes.", Data = archivedList });
                }
                else if (archivedList.Count == 0)
                {
                    return Ok(new { Success = true, message = "There are no Archived notes." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Something went wrong." });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpGet]
        [Route("Trashed")]
        public IActionResult GetTrash()
        {
            try
            {
                long userId = GetTokenId();
                var trashList = _noteBL.GetTrash(userId);

                if (trashList.Count != 0)
                {
                    return this.Ok(new { Success = true, message = "These are your Trashed Notes.", Data = trashList });
                }
                else if (trashList.Count == 0)
                {
                    return Ok(new { Success = true, message = "There are no trashed notes." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Something went wrong." });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpPut]
        [Route("{noteId}/Update")]
        public IActionResult UpdateNotes(long noteId, NotesModel notesModel)
        {
            try
            {
                var userId = GetTokenId();
                var result = this._noteBL.UpdateNotes(noteId, userId, notesModel);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Note Updated SuccessFully.", noteId });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Note updation failed." });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }

        }

        [HttpPut]
        [Route("{noteId}/Colour")]
        public IActionResult ChangeColor(long noteId, NotesModel notesModel)
        {
            long userId = GetTokenId();
            bool result = _noteBL.ChangeColor(noteId, userId, notesModel);

            try
            {
                if (result == true)
                {
                    return Ok(new { Success = true, message = "Color changed Successfully !!" });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Color not changed !!" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpPut]
        [Route("{noteId}/Pin")]
        public IActionResult IsPinned(long noteId)
        {
            long userId = GetTokenId();
            bool result = _noteBL.IsPinned(noteId, userId);

            try
            {
                if (result == true)
                {
                    return Ok(new { Success = true, message = "Successful" });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unsuccessful" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }


        [HttpPut]
        [Route("{noteId}/Trash/Restore")]
        public IActionResult Restore(long noteId)
        {
            try
            {
                long userId = GetTokenId();
                bool result = _noteBL.Restore(noteId, userId);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Note restored from trash Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unsuccessful" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpPut]
        [Route("{noteId}/Archive")]
        public IActionResult IsArchive(long noteId)
        {
            long userId = GetTokenId();
            bool result = _noteBL.IsArchive(noteId, userId);

            try
            {
                if (result == true)
                {
                    return Ok(new { Success = true, message = "Note archived Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unsuccessful" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpPut]
        [Route("{noteId}/Archive/Unarchive")]
        public IActionResult Unarchive(long noteId)
        {
            try
            {
                long userId = GetTokenId();
                bool result = _noteBL.UnArchive(noteId, userId);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Note Unarchived Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unsuccessful" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpPut]
        [Route("{noteId}/Reminder")]
        public IActionResult ChangeRemainder(long noteId, DateTime dateTime)
        {
            try
            {
                long userId = GetTokenId();
                bool result = _noteBL.ChangeRemainder(noteId, userId, dateTime);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Note Reminder changed Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "No Reminder is added to this note." });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpPut]
        [Route("{noteId}/Image")]
        public IActionResult AddImage(long noteId, IFormFile formFile)
        {
            try
            {
                long userId = GetTokenId();
                bool result = _noteBL.AddImage(noteId, userId, formFile);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Image added Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Failed to add image." });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpDelete]
        [Route("{noteId}/Image")]
        public IActionResult DeleteImage(long noteId)
        {
            try
            {
                long userId = GetTokenId();
                bool result = _noteBL.DeleteImage(noteId, userId);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Image removed from the note Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Failed to remove image." });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpDelete]
        [Route("{noteId}/Trash")]
        public IActionResult IsTrash(long noteId)
        {
            long userId = GetTokenId();
            bool result = _noteBL.IsTrash(noteId, userId);

            try
            {
                if (result == true)
                {
                    return Ok(new { Success = true, message = "Note moved to trash Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Unsuccessful" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpDelete]
        [Route("Trash/Empty")]
        public IActionResult EmptyTrash()
        {
            try
            {
                long userId = GetTokenId();
                bool result = _noteBL.EmptyTrash(userId);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Deleted all trashed notes Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Note deletion failed." });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpDelete]
        [Route("{noteId}/Trash/Delete")]
        public IActionResult DeleteForever(long noteId)
        {
            try
            {
                long userId = GetTokenId();
                bool result = _noteBL.DeleteForever(noteId, userId);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Deleted forever from trash Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Note deletion failed." });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpDelete]
        [Route("{noteId}/Reminder")]
        public IActionResult DeleteRemainder(long noteId)
        {
            try
            {
                long userId = GetTokenId();
                bool result = _noteBL.DeleteRemainder(noteId, userId);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Note Reminder removed Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "No Reminder is added to this note." });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }
    }
}
