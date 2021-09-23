using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace FundooNotes.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class LabelController : ControllerBase
    {
        private ILabelBL _labelBL;

        public LabelController(ILabelBL labelBL)
        {
            _labelBL = labelBL;
        }

        private long GetTokenId()
        {
            return Convert.ToInt64(User.FindFirst("Id").Value);
        }

        [HttpPost]
        [Route("{noteId}/note")]
        public IActionResult AddLabel(long noteId, LabelModel labelModel)
        {
            try
            {
                long userId = GetTokenId();
                var result = _labelBL.AddLabel(noteId, userId, labelModel);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Label added Successfully !!" });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Label already exists !!" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }


        [HttpPost]
        public IActionResult AddLabelToUser(LabelModel labelModel)
        {
            try
            {
                long userId = GetTokenId();
                bool result = _labelBL.AddLabelToUser(userId, labelModel);

                if (result == true)
                {
                    return Ok(new { Success = true, message = "Label added Successfully !!" });
                }
                else
                {
                    return BadRequest(new { Success = false, message = "Label already exists !!" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Success = false, message = e.Message, stackTrace = e.StackTrace });
            }
        }

        [HttpGet]
        [Route("{noteId}")]
        public IActionResult GetNoteLables(long noteId)
        {
            try
            {
                long userId = GetTokenId();
                List<Label> labelList = _labelBL.GetNoteLables(noteId, userId);

                if (labelList.Count != 0)
                {
                    return this.Ok(new { Success = true, message = "These are Your all the Labels.", Data = labelList });
                }
                else if (labelList.Count == 0)
                {
                    return BadRequest(new { Success = false, message = "No Label is added to this note." });
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
        public IActionResult GetUserLabels()
        {
            try
            {
                long userId = GetTokenId();
                List<Label> labelList = _labelBL.GetUserLabels(userId);

                if (labelList.Count != 0)
                {
                    return this.Ok(new { Success = true, message = "These are Your all the Labels.", Data = labelList });
                }
                else if (labelList.Count == 0)
                {
                    return BadRequest(new { Success = false, message = "No Label is added." });
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
    }
}
