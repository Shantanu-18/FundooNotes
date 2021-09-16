using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
    public class ForgotPassModel
    {
        [Required]
        public string Email { get; set; }
    }
}
