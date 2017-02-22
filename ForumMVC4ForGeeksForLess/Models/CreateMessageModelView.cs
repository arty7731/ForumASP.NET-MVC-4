using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ForumMVC4ForGeeksForLess.Models
{
    public class CreateMessageModelView
    {
        [Required]
        [Display(Name = "Text message")]
        [MaxLength(512, ErrorMessage = "Exceeded the maximum record length")]
        [MinLength(24, ErrorMessage = "Minimum record length 24 char")]
        public string TextMessage { get; set; }
    }
}