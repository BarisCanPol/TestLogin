using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;
using TestLogin.DAL.ORM.Enum;

namespace TestLogin.UI.Areas.Admin.Models.LoginVM
{
    public class Class1
    {
        public Guid ID { get; set; }

        [StringLength(255, MinimumLength = 2)]
        [Required(ErrorMessage = "Please enter your username !")]   
        public string UserName { get; set; }      
        
        [Required(ErrorMessage = "Please enter your password !")]
        [DataType(DataType.Password, ErrorMessage = "Password  must contain a Number , hasbdha !!")]
        [MembershipPassword(PasswordStrengthError ="Password is weak please insert a nonnumerical and nonalphatical character",MinPasswordLengthError ="Please enter min 7 characters  " ,MinNonAlphanumericCharactersError ="Please enter a nonnumerical character .." )]
        public string Password { get; set; }

        [Compare("Password",ErrorMessage ="Password is not same !!")]
        [DataType(DataType.Password)]        
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please select a Role !")]
        public Role Role { get; set; }


    }
}