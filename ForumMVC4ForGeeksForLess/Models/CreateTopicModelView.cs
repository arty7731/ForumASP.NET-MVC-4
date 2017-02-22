using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ForumMVC4ForGeeksForLess.Models
{
    public class CreateTopicModelView
    {
        //Title
        [Required]
        [Display(Name = "Title!")]
        [MaxLength(128, ErrorMessage = "Exceeded the maximum record length")]
        [MinLength(8, ErrorMessage = "Minimum record length 8 char")]
        public string Title { get; set; }
        //Text
        [Required]
        [Display(Name = "Text!")]
        [MaxLength(1024, ErrorMessage = "Exceeded the maximum record length")]
        [MinLength(24, ErrorMessage = "Minimum record length 24 char")]
        public string Text { get; set; }
    }
}