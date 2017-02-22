using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ForumMVC4ForGeeksForLess.Domain.Entities
{
    public class User
    {
        //ID
        public int Id { get; set; }
        //Login
        [Required]
        [Display(Name = "Login")]
        //[MaxLength(24, ErrorMessage = "Exceeded the maximum record length")]
        public string Login { get; set; }
        //Nickname
        [Required]
        [Display(Name = "Nickname")]
        //[MaxLength(24, ErrorMessage = "Exceeded the maximum record length")]
        public string Nickname { get; set; }
        //Image
        public byte[] Avatar { get; set; }
        //Password
        [Required]
        [Display(Name = "Password")]
        //[MaxLength(128, ErrorMessage = "Exceeded the maximum record length")]
        public string Password { get; set; }
        //Topic list
        public ICollection<Topic> Topics { get; set; }
        //Message list
        public ICollection<Message> Messages { get; set; }
    }
}