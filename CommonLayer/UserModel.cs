using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
    public class UserModel
    {
        [Required]
        [RegularExpression("^[A-Z][a-z]{1,}",ErrorMessage ="Name should start with capital letters and" +
            "should contain atleast 2 characters.")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression("^[A-Z][a-z]{1,}", ErrorMessage = "Name should start with capital letters and" +
            "should contain atleast 2 characters.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^((?=.*[A-Z][a-z])(?=.*[0-9])(?=.*[!@#$%^&*-_.])(?=.{8,}))", 
            ErrorMessage = "Password should contain minimum 8 character atleast one upper case character" +
            " and atleast one numeric value")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
