using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ForumMVC4ForGeeksForLess.Models
{
    public class RegistrationModelView
    {
        //Login
        [Required]
        [Display(Name = "Login")]
        [MinLength(6, ErrorMessage = "Minimum login length 6 char")]
        [MaxLength(24, ErrorMessage = "Exceeded the maximum record length")]
        public string Login { get; set; }
        //NickName
        [Required]
        [Display(Name = "Nickname")]
        [MinLength(6, ErrorMessage = "Minimum login length 6 char")]
        [MaxLength(24, ErrorMessage = "Exceeded the maximum record length")]
        public string Nickname { get; set; }
        //Password
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [MinLength(6, ErrorMessage = "Minimum password length 6 char")]
        [MaxLength(24, ErrorMessage = "Exceeded the maximum record length")]
        public string Password { get; set; }
        //ConfirmPassword
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        //Image
        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Avatar")]
        public HttpPostedFileBase Avatar { get; set; }
    }
}