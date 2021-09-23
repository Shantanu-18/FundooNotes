using BusinessLayer.Interface;
using CommonLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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

        private string GetEmail()
        {
            return User.FindFirst(ClaimTypes.Email).Value.ToString();
        }

        [HttpPost]
        [Route("{noteId}")]
        public IActionResult AddLabel(long noteId, LabelModel labelModel)
        {
            long userId = GetTokenId();
            var result = _labelBL.AddLabel(noteId, userId, labelModel);
            try
            {
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
    }
}
