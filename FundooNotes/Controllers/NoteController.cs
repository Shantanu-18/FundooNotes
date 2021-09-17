using BusinessLayer.Interface;
using BusinessLayer.Services;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            long userId = Convert.ToInt64(User.FindFirst("Id").Value);
            return userId;
        }

        [HttpPost("AddNote")]
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

        [HttpGet("GetNotes")]
        public IActionResult GetNotes()
        {
            try
            {
                long userId = GetTokenId();
                var NotesList = _noteBL.GetAllNotes(userId);

                return this.Ok(new { Success = true, message = "Get User Notes Successfully.", Data = NotesList });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("DeleteNotes")]
        public IActionResult DeleteNotes(long id)
        {
            try
            {
                long userId = GetTokenId();
                var result = this._noteBL.DeleteNotes(id, userId);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Note Deleted SuccessFully.", id });
                }
                else
                {
                    return this.BadRequest(new { Success = false, message = "Note deletion failed." });
                }
            }
            catch (Exception e)
            {
                return this.BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }

        }

        [HttpPut("UpdateNotes")]
        public IActionResult UpdateNotes(long id, NotesModel notesModel)
        {
            try
            {
                var userId = GetTokenId();
                var result = this._noteBL.UpdateNotes(id, userId, notesModel);

                if (result == true)
                {
                    return this.Ok(new { Success = true, message = "Note Updated SuccessFully.", id });
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

        
        [HttpPut("ChangeColour")]
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

        [HttpPut("isPinned")]
        public IActionResult IsPinned(long noteId,bool value)
        {
            long userId = GetTokenId();
            bool result = _noteBL.IsPinned(noteId, userId, value);

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

    }
}
