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
            long userId = Convert.ToInt64(User.FindFirst("Id").Value);
            return userId;
        }

        [HttpPost]
        [Route("noteId/AddCollaboration")]
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
    }
}
