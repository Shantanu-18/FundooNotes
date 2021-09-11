using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
    public class LogInModel
    {
        [Required]
        public string email { get; set; }
        
        [Required]
        public string password { get; set; }
    }
}
