using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace FundooNotes.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class CollaborationController : ControllerBase
    {
        private ICollaborationBL _collaborationBL;

        public CollaborationController(ICollaborationBL collaborationBL)
        {
            _collaborationBL = collaborationBL;
        }

        private long GetTokenId()
        {
            return Convert.ToInt64(User.FindFirst("Id").Value);
        }

        [HttpPost]
        [Route("{noteId}")]
        public IActionResult AddCollab(long noteId, CollaborationModel collaboration)
        {
            try
            {
                long userId = GetTokenId();
                var result = _collaborationBL.AddCollab(noteId, userId, collaboration.collabEmail);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Collaboration Added Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Adding Collaboration failed." });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpGet]
        [Route("{noteId}")]
        public IActionResult GetCollab(long noteId)
        {
            try
            {
                long userId = GetTokenId();
                var collabList = _collaborationBL.GetCollab(noteId, userId);

                if (collabList.Count != 0)
                {
                    return Ok(new { success = true, message = "These are the Collaborations of these note.", data = collabList });
                }
                else if (collabList.Count == 0)
                {
                    return Ok(new { Success = true, message = "No collaboration found." });
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

        [HttpDelete]
        [Route("{noteId}")]
        public IActionResult RemoveCollab(long noteId, CollaborationModel collaborationModel)
        {
            try
            {
                long userId = GetTokenId();
                var result = _collaborationBL.RemoveCollab(noteId, userId, collaborationModel.collabEmail);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Collaboration Removed Successfully." });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Removing Collaboration failed." });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }
    }
}
